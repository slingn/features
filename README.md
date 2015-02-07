SlingN.Features
=====================

Simple Feature Toggle library for .NET

SlingN.Features is a simple library for controlling feature toggles/flags in your .NET applications.

To get started, you define a feature toggle:

<code>
Feature.Add("DisplayHomePageToGoldUsers", true);
</code>

When you want to check the status of a feature toggle:

<code>
var shouldDisplayHomePageToGoldUsers = Feature.IsEnabled("DisplayHomePageToGoldUsers");
</code>

Feature toggles can also be defined using a runtime evaluation as such:

<code>
Feature.Add("DisplayHomePageToGoldUsers", () => { 
	HttpContext.Current.Request.QueryString["gold"] == "true" 
});
</code>

Feature toggles can also be initialized via AppSetting:

<code>
&lt;appSetting key="Feature.DisplayHomePageToGoldUsers" value="true" /&gt;
</code>

<small><i>NOTE: your feature toggle AppSetting key should be prefixed with Feature.</i></small>

<code>
Feature.InitializeFromAppSettings();
</code>

When you want to check the status of a feature toggle initalized from an AppSetting 
you would do it just as you would any other feature toggle:

<code>
var shouldDisplayHomePageToGoldUsers = Feature.IsEnabled("DisplayHomePageToGoldUsers");
</code>
