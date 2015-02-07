# Features

Features is a library which provides a simple implementation of a [Feature Toggle].

##Installing via Nuget
```
Install-Package slingn.features
```

###Usage

To get started, you define a feature toggle:
```
Feature.Add("DisplayHomePageToGoldUsers", true);
```

When you want to check the status of a feature toggle:
```
var shouldDisplayHomePageToGoldUsers = Feature.IsEnabled("DisplayHomePageToGoldUsers");
```

Feature toggles can also be initialized via AppSetting:
```
<appSetting key="Feature.DisplayHomePageToGoldUsers" value="true" />
```

On application start-up
```
Feature.InitializeFromAppSettings();
```

When you want to check the status of a feature toggle initalized from an AppSetting 
you would do it just as you would any other feature toggle:
```
var shouldDisplayHomePageToGoldUsers = Feature.IsEnabled("DisplayHomePageToGoldUsers");
```

Feature toggles can also be defined using a runtime evaluation as such:
```
Feature.Add("DisplayHomePageToGoldUsers", () => { 
	HttpContext.Current.Request.QueryString["gold"] == "true" 
});
```

###Overview
A [Feature Toggle] provides a simple mechanism to enable/disable execution of a specific block of code. 
In a continuous delivery environment, Feature Toggles allow for developers to disable portions of code/features 
which are actively under development, allowing for code to be released straight from the trunk/master branch at any time.
Additionally, Feature Toggles come in handly when features intend to be [Canary Released].


### Version
1.0.0

*** SlingN Systems LLC. - slingn.features - written by Kasi Prasad***

[Feature Toggle]:http://martinfowler.com/bliki/FeatureToggle.html
[Canary Released]:http://martinfowler.com/bliki/CanaryRelease.html