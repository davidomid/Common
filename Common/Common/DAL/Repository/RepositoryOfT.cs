//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace www.DavidOmid.com.DAL.Common.Repository
//{
//    public abstract class Repository<T> : IRepository<T> where T : class
//    {
//        //public abstract void Add(T item);
//        //public abstract IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

//        //public virtual T FindByKey(params KeyValuePair<Expression<Func<T, object>>, object>[] keyValues)
//        //{
//        //    Dictionary<string, object> keyValuesDictionary = new Dictionary<string, object>();
//        //    foreach (KeyValuePair<Expression<Func<T, object>>, object> keyValue in keyValues)
//        //    {
//        //        Expression<Func<T, object>> expression = keyValue.Key;
//        //        MemberExpression memberExpression = expression.Body as MemberExpression;
//        //        if (memberExpression == null)
//        //        {
//        //            throw new NullReferenceException("Invalid member expression.");
//        //        }

//        //        string propertyName = memberExpression.Member.Name;
//        //        keyValuesDictionary.Add(propertyName, keyValue.Value);
//        //    }

//        //    return this.FindByKey(keyValuesDictionary);
//        //}

//        //public abstract T FindByKey(Dictionary<string, object> keyValues);

//        //public virtual T FindByKey(params KeyValuePair<string, object>[] keyValues)
//        //{
//        //    Dictionary<string, object> keyValuesDictionary = keyValues.ToDictionary(k => k.Key, v => v.Value);
//        //    return this.FindByKey(keyValuesDictionary);
//        //}

//        //public virtual T FindByKey(IDictionary<Expression<Func<T, object>>, object> keyValues)
//        //{
//        //    KeyValuePair<Expression<Func<T, object>>, object>[] keyValuesArray = keyValues.ToArray();
//        //    return this.FindByKey(keyValuesArray);
//        //}

//        //public abstract IEnumerable<T> GetAll();
//        //public abstract void Remove(T item);
//        //public abstract void Update(T item);
//    }
//}