using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {

            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var personEntity = _converter.Parse(book);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public BookVO Update(BookVO book)
        {
            var personEntity = _converter.Parse(book);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
