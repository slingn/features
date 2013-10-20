SlingN.Features
=====================

Simple Feature Toggle library for .NET

SlingN.Features is a simple library for controlling feature toggles/flags in your .NET applications.

To get started, you define a feature toggle:

<code>
Features.Add("DisplayHomePageToGoldUsers", true);
</code>

When you want to check the status of a feature toggle:

<code>
var shouldDisplayHomePageToGoldUsers = Features.IsEnabled("DisplayHomePageToGoldUsers");
</code>

Feature toggles can also be defined using a runtime evaluation as such:

<code>
Features.Add("DisplayHomePageToGoldUsers", () => { 
	HttpContext.Current.Request.QueryString["gold"] == "true" 
});
</code>

Feature toggles can also be initialized via AppSetting:

<code>
&lt;appSetting key="Feature.DisplayHomePageToGoldUsers" value="true" /&gt;
</code>

<code>
Features.InitializeFromAppSettings();
</code>
