using BlazorWeb;
using BlazorWeb.Interfaces;
using BlazorWeb.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ICompetitionService, CompetitionService>();
builder.Services.AddSingleton<ITeamService, TeamService>();
builder.Services.AddSingleton<IExerciseService, ExerciseService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ICatalogueService, CatalogueService>();

// Auth0
builder.Services.AddOidcAuthentication(options =>
	{
		builder.Configuration.Bind("Auth0", options.ProviderOptions);
		options.ProviderOptions.ResponseType = "code";
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
