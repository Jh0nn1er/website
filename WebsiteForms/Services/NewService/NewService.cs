﻿using WebsiteForms.Database.Entities;
using WebsiteForms.Repositories.Contracts;
using WebsiteForms.Services.RequestService;

namespace WebsiteForms.Services.NewService
{
    public class NewService : INewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int? Add(New request)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                _unitOfWork.News.Add(request);
                _unitOfWork.Save();

                transaction.Commit();

                return request.Id;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }

        public IEnumerable<New> GetAll()
        {
            return _unitOfWork.News.GetAll();
        }

        public New GetById(int id)
        {
            return _unitOfWork.News.GetById(id);

        }

        public int? Update(New news)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                _unitOfWork.News.Update(news);
                _unitOfWork.Save();

                transaction.Commit();

                return news.Id;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return 0;
            }
        }
    }
}
