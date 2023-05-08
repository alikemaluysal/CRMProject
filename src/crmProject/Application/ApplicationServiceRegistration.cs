using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Customers;
using Application.Services.Departments;
using Application.Services.Documents;
using Application.Services.DocumentTypes;
using Application.Services.Employees;
using Application.Services.Genders;
using Application.Services.Notifications;
using Application.Services.Offers;
using Application.Services.OfferStatuses;
using Application.Services.Regions;
using Application.Services.Requests;
using Application.Services.RequestStatuses;
using Application.Services.Sales;
using Application.Services.Settings;
using Application.Services.StatusTypes;
using Application.Services.TaskEntities;
using Application.Services.Titles;
using Application.Services.UserAddresses;
using Application.Services.UserEmails;
using Application.Services.UserPhones;
using Application.Services.TaskStatuses;
using Application.Services.UserStatuses;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<ICustomersService, CustomersManager>();
        services.AddScoped<IDepartmentsService, DepartmentsManager>();
        services.AddScoped<IDocumentsService, DocumentsManager>();
        services.AddScoped<IDocumentTypesService, DocumentTypesManager>();
        services.AddScoped<IEmployeesService, EmployeesManager>();
        services.AddScoped<IGendersService, GendersManager>();
        services.AddScoped<INotificationsService, NotificationsManager>();
        services.AddScoped<IOffersService, OffersManager>();
        services.AddScoped<IOfferStatusService, OfferStatusManager>();
        services.AddScoped<IRegionsService, RegionsManager>();
        services.AddScoped<IRequestsService, RequestsManager>();
        services.AddScoped<IRequestStatusService, RequestStatusManager>();
        services.AddScoped<ISalesService, SalesManager>();
        services.AddScoped<ISettingsService, SettingsManager>();
        services.AddScoped<IStatusTypesService, StatusTypesManager>();
        services.AddScoped<ITaskEntitiesService, TaskEntitiesManager>();
        services.AddScoped<ITitlesService, TitlesManager>();
        services.AddScoped<IUserAddressesService, UserAddressesManager>();
        services.AddScoped<IUserEmailsService, UserEmailsManager>();
        services.AddScoped<IUserPhonesService, UserPhonesManager>();
        services.AddScoped<ITaskStatusService, TaskStatusManager>();
        services.AddScoped<IUserStatusService, UserStatusManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
