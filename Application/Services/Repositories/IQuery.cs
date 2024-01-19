public interface IQuery<T> // bu interface i implemente eden class ların queryable döndürmesini sağlar
{
    IQueryable<T> Query(); // bu bize bir queryable dönecek,sql sorgusu dönecek
}