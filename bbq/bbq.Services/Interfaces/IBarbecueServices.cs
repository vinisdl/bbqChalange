using bbq.Domain.Entities;
using bbq.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace bbq.Services.Interfaces
{
    public interface IBarbecueServices
    {
        Barbecue Add(Barbecue barbecue);
        Barbecue AddParticipant(int idBarbecue, BarbecueParticipant barbecueParticipant);
        Barbecue RemoveParticipant(int idBarbecue, int idBarbecueParticipant);
        BarbecueDetailsViewModel GetBarbecueDetails(int idBarbecue);

    }
}
