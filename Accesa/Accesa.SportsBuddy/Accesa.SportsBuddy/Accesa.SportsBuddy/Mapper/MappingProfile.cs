using Accesa.SportsBuddy.Controllers.Models;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SportCenterAdmin, SportCenterAdminDTO>();
            CreateMap<SportCenterAdminDTO, SportCenterAdmin>();
            CreateMap<User, TraineeDTO>();
            CreateMap<TraineeDTO, User>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            CreateMap<SportCenter, SportCenterDTO>();
            CreateMap<SportCenterDTO, SportCenter>();
            CreateMap<Role, RoleAdministratedDTO>();
            CreateMap<RoleAdministratedDTO, Role>();
            CreateMap<Address, AddressSportCenterDTO>();
            CreateMap<AddressSportCenterDTO, Address>();
            CreateMap<AdministratedSportCenter, AdministratedSportCenterDTO>();
            CreateMap<EventCreatedBySportCenter, EventCreatedBySportCenterDTO>();
            CreateMap<EventCreatedBySportCenterDTO, EventCreatedBySportCenter>();
            CreateMap<JoinEventDTO, JoinEvent>();
            CreateMap<JoinEvent, JoinEventDTO>();
            CreateMap<TrainingProgram, TrainingProgramDTO>();
            CreateMap<TrainingProgramDTO, TrainingProgram>();
            CreateMap<TrainerTrainingProgramDTO, TrainerTrainingProgram>();
            CreateMap<TrainerTrainingProgram, TrainerTrainingProgramDTO>();
            CreateMap<ActivityTrainerInfo, Trainer>();
            CreateMap<Trainer, ActivityTrainerInfo>();
            CreateMap<TrainerDTO, Trainer>();
            CreateMap<Trainer, TrainerDTO>();
            CreateMap<TrainerSportCenterDTO, TrainerSportCenter>();
            CreateMap<TrainerSportCenter, TrainerSportCenterDTO>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<Challenge, ChallengeDTO>();
            CreateMap<ChallengeDTO, Challenge>();
            CreateMap<TraineeChallengeDTO, TraineeChallenge>();
            CreateMap<TraineeChallenge, TraineeChallengeDTO>();
            CreateMap<JoinEventCreatedBySportCenterDTO, JoinEventCreatedBySportCenter>();
            CreateMap<JoinEventCreatedBySportCenter, JoinEventCreatedBySportCenterDTO>();
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
            CreateMap<TrainerDTO, TrainerInfo>()
                .ForMember(t => t.TrainerId, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.Id, t => t.MapFrom(t => t.UserId))
                .ForMember(t => t.FirstName, t => t.MapFrom(t => t.UserFirstName))
                .ForMember(t => t.LastName, t => t.MapFrom(t => t.UserLastName))
                .ForMember(t => t.BirthDate, t => t.MapFrom(t => t.UserBirthDate))
                .ForMember(t => t.Gender, t => t.MapFrom(t => t.UserGender))
                .ForMember(t => t.PhoneNumber, t => t.MapFrom(t => t.UserPhoneNumber))
                .ForMember(t => t.Email, t => t.MapFrom(t => t.UserEmail))
                .ForMember(t => t.Password, t => t.MapFrom(t => t.UserPassword))
                .ForMember(t => t.AddressNavigation, t => t.MapFrom(t => t.UserAddressNavigation))
                .ForMember(t => t.CreatedAt, t => t.MapFrom(t => t.UserCreatedAt))
                .ForMember(t => t.Role, t => t.MapFrom(t => t.UserRole));
            CreateMap<TrainerInfo, Trainer>()
                .ForMember(t => t.UserId, t => t.MapFrom(t => t.Id));
            CreateMap<Trainer, TrainerInfo>()
                .ForMember(t => t.TrainerId, t => t.MapFrom(t => t.Id))
                .ForMember(t => t.Id, t => t.MapFrom(t => t.UserId))
                .ForMember(t => t.FirstName, t => t.MapFrom(t => t.User.FirstName))
                .ForMember(t => t.LastName, t => t.MapFrom(t => t.User.LastName))
                .ForMember(t => t.BirthDate, t => t.MapFrom(t => t.User.BirthDate))
                .ForMember(t => t.Gender, t => t.MapFrom(t => t.User.Gender))
                .ForMember(t => t.PhoneNumber, t => t.MapFrom(t => t.User.PhoneNumber))
                .ForMember(t => t.Email, t => t.MapFrom(t => t.User.Email))
                .ForMember(t => t.Password, t => t.MapFrom(t => t.User.Password))
                .ForMember(t => t.AddressNavigation, t => t.MapFrom(t => t.User.AddressNavigation))
                .ForMember(t => t.CreatedAt, t => t.MapFrom(t => t.User.CreatedAt))
                .ForMember(t => t.Role, t => t.MapFrom(t => t.User.Role));
            CreateMap<TrainerInfo, User>();
        }
    }
}