using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class TokenRepository : Database, IReopsitory<Token, string, Token>
    {
        public Token Add(Token entity)
        {
            Context.Tokens.Add(entity);
            return Context.SaveChanges() > 0 ? entity : null;
        }

        public Token Update(Token entity)
        {
            var token = GetById(entity.TKey);
            if (token == null) return null;
            Context.Entry(token).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0 ? entity : null;
        }

        public Token Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Token GetById(string id) => Context.Tokens.FirstOrDefault(x => x.TKey == id);

        public List<Token> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}