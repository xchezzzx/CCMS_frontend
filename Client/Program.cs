using BlazorWeb;
using BlazorWeb.Interfaces;
using BlazorWeb.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICatalogueService, CatalogueService>();

// Auth0
//builder.Services.AddOidcAuthentication(options =>
//	{
//		builder.Configuration.Bind("Auth0", options.ProviderOptions);
//});

builder.Services
		.AddAuth0Authentication(options =>
		{
			builder.Configuration.Bind("auth0", options.ProviderOptions);
		});

// Blazorise
builder.Services
	.AddBlazorise(options =>
	{
		options.Immediate = true;
	})
	.AddBootstrapProviders()
	.AddFontAwesomeIcons();

var app = builder.Build().RunAsync();
