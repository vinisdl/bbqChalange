using bbq.Domain.Entities;
using bbq.Domain.ViewModel;
using bbq.Repository.Interfaces;
using bbq.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bbq.Services.Layers
{
    public class BarbecueServices : IBarbecueServices
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public BarbecueServices(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }
        public Barbecue Add(Barbecue barbecue)
        {
            if (!barbecue.IsValid())
                throw new ArgumentException("Barbecue entity is not valid");

            var bbq = _barbecueRepository.Add(barbecue);
            _barbecueRepository.Commit();

            return bbq;
        }

        public Barbecue AddParticipant(int idBarbecue, BarbecueParticipant barbecueParticipant)
        {
            if (!barbecueParticipant.IsValid())
                throw new ArgumentException("Barbecue participant entity is not valid");
            if (idBarbecue < 1)
                throw new ArgumentException("Barbecue Id is not valid");

            var bbq = _barbecueRepository.GetById(idBarbecue); if (bbq == null)
                throw new ArgumentException("Barbecue not found");
            bbq.BarbecueParticipants.Add(barbecueParticipant);

            _barbecueRepository.Update(bbq);
            _barbecueRepository.Commit();

            return bbq;
        }

        public BarbecueDetailsViewModel GetBarbecueDetails(int idBarbecue)
        {
            if (idBarbecue < 1)
                throw new ArgumentException("Barbecue Id is not valid");

            var bbq = _barbecueRepository.GetById(idBarbecue);
            if (bbq == null)
                throw new ArgumentException("Barbecue not found");



            return new BarbecueDetailsViewModel()
            {
                BarbecueParticipants = bbq.BarbecueParticipants.Select(bbqp => new BarbecueParticipantViewModel()
                {
                    Id = bbqp.Id,
                    Contribuition = bbqp.Contribuition,
                    Name = bbqp.Name
                }).ToList(),
                Id = bbq.Id,
                ScheduleDate = bbq.ScheduleDate,
                SampleContribution = bbq.SampleContribution,
                SampleContributionWithoutDrink = bbq.SampleContributionWithoutDrink
            };

        }

        public Barbecue RemoveParticipant(int idBarbecue, int idBarbecueParticipant)
        {
            if (idBarbecue < 1)
                throw new ArgumentException("Barbecue Id is not valid");
            if (idBarbecueParticipant < 1)
                throw new ArgumentException("Barbecue Participant Id is not valid");

            var bbq = _barbecueRepository.GetById(idBarbecue);
            if (bbq == null)
                throw new ArgumentException("Barbecue not found");

            bbq.BarbecueParticipants.RemoveAll(bp => bp.Id == idBarbecueParticipant);
            _barbecueRepository.Update(bbq);
            _barbecueRepository.Commit();

            return bbq;
        }
    }
}
