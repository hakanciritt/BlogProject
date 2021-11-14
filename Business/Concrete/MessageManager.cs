using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public IDataResult<List<Message>> GetMessageListByWriterMail(string mail)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(x => x.Receiver == mail));
        }
    }
}
