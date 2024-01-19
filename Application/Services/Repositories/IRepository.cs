using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

public interface IRepository<TEntity,TEntityId>:IQueryable<TEntity> where TEntity : BaseEntity<TEntityId> 
{
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate, // lambda expression(where ..) için kullanılır
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, // include ile ilişkili tabloları getirir,join desteği sağlar
        bool withDeleted= false, // silinmiş kayıtları da getirir
        bool enableTracking=true, // tracking özelliğini açar
        CancellationToken cancellationToken = default); // işlemi iptal etmek için kullanılır
    
    Task<IPaginate<TEntity>> GetListAsync
    (
        Expression<Func<TEntity, bool>>? predicate = null, // lambda ile where vs yazmak için kullanılır,null çünkü zorunlu değil
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, // sıralama için kullanılır
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, // join ile ilgili tabloları getirmek için kullanılır
        int index = 0, // kaçıncı sayfa default 0
        int size = 10, // her sayfada kaç kayıt gelecek default 10
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<TEntity>> GetListByDynamicAsync
    (
        DynamicQuery dynamic, // dynamic query için
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        int index = 0,
        int size = 10,  
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync
    (
        Expression<Func<TEntity, bool>>? predicate=null, // pradicate geçmezsem data var mı diye bakar, geçersem predicate e göre(o koşulda) data var mı diye bakar
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<TEntity> AddAsync(TEntity entity); // bana bir entity ver, ben onu db ye ekle
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities); // bana bir entity listesi ver, ben onları db ye ekle(bulk insert)
    Task<TEntity> UpdateAsync(TEntity entity); // bana bir entity ver, ben onu db de güncelle
    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities); // bana bir entity listesi ver, ben onları db de güncelle(bulk update)
    Task<TEntity> DeleteAsync(TEntity entity,bool permanent = false); // permanent = false ise db de silinmiş olarak işaretler, true ise db den siler(soft delete)
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities,bool permanent = false); // bulk delete
}