﻿using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Security.Authentication;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    services.AddMassTransit(busConfigurator =>
    {
        var entryAssembly = Assembly.GetExecutingAssembly();
        busConfigurator.AddConsumers(entryAssembly);
        busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
        {
            busFactoryConfigurator.Host("jackal-01.rmq.cloudamqp.com", 5671, "mxixoldu", h =>
        {
            h.Username("mxixoldu");
            h.Password("dGSjTThRm61xWXfmKFGxi79hc_nW-awP");

            h.UseSsl(s =>
            {
                s.Protocol = SslProtocols.Tls12;
            });
        });
            busFactoryConfigurator.ConfigureEndpoints(context);
        });
    });
});

var app = builder.Build();

app.Run();