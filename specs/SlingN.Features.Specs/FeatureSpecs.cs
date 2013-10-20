using System;
using System.Configuration;
using Machine.Specifications;
using SlingN.Features.Framework;

namespace SlingN.Features.Specs.FeatureSpecs
{
    public class When_checking_whether_a_feature_is_enabled_for_a_feature_whose_name_is_unknown
    {
        Because of = () =>
        {
            _result = Feature.IsEnabled("Anything");
        };

        It should_return_false = () => _result.ShouldBeFalse();

        private static bool _result;
    }

    public class When_checking_whether_a_feature_is_enabled_for_a_feature_whose_flag_value_is_set_to_false
    {
        Establish context = () => Feature.Add("MyFeature", false);

        Because of = () =>
        {
            _result = Feature.IsEnabled("MyFeature");
        };

        It should_return_false = () => _result.ShouldBeFalse();

        private static bool _result;
    }

    public class When_checking_whether_a_feature_is_enabled_for_a_feature_whose_flag_value_is_set_to_true
    {
        Establish context = () => Feature.Add("TestFeature", true);

        Because of = () => _result = Feature.IsEnabled("TestFeature");

        It should_return_true = () => _result.ShouldBeTrue();

        private static bool _result;
    }

    public class When_checking_whether_a_feature_is_enabled_for_a_feature_which_has_been_defined_more_than_once
    {
        Establish context = () => Feature.Add("RedefinedFeature", true);

        Because of = () =>
        {
            _fistResult = Feature.IsEnabled("RedefinedFeature");
            Feature.Add("RedefinedFeature", false);
            _secondResult = Feature.IsEnabled("RedefinedFeature");
        };

        It should_use_its_latest_value = () =>
        {
            _fistResult.ShouldBeTrue();
            _secondResult.ShouldBeFalse();
        };

        private static bool _fistResult;
        private static bool _secondResult;
    }

    public class When_checking_whether_a_feature_is_enabled_which_has_been_defined_using_a_lambda_which_evalutes_to_true_at_runtime
    {
        Establish context = () => Feature.Add("LambdaFeature", () => true);

        Because of = () => { _result = Feature.IsEnabled("LambdaFeature"); };

        It should_return_true = () => _result.ShouldBeTrue();

        private static bool _result;
    }

    public class When_checking_whether_a_feature_is_enabled_which_has_been_defined_using_a_lambda_which_evalutes_to_false_at_runtime
    {
        Establish context = () => Feature.Add("LambdaFeature", () => false);

        Because of = () => { _result = Feature.IsEnabled("LambdaFeature"); };

        It should_return_false = () => _result.ShouldBeFalse();

        private static bool _result;
    }

    public class When_checking_whether_a_feature_is_enabled_which_has_been_defined_using_a_lambda_which_throws_an_exception_at_runtime
    {
        Establish context = () => Feature.Add("LambdaFeature", () => { throw new Exception("Something went wrong"); });

        Because of = () => { _result = Feature.IsEnabled("LambdaFeature"); };

        It should_return_false = () => _result.ShouldBeFalse();

        private static bool _result;
    }

    public class When_features_are_initialized_from_app_settings_containing_features
    {
        Establish context = () =>
        {
            ConfigurationManager.AppSettings["Feature.AppSettingFeature1"] = "true";
            ConfigurationManager.AppSettings["Feature.AppSettingFeature2"] = "false";
        };

        Because of = () => Feature.InitializeFromAppSettings();


        It should_define_features_for_each_app_setting_feature = () =>
        {
            Feature.IsEnabled("AppSettingFeature1").ShouldBeTrue();
            Feature.IsEnabled("AppSettingFeature2").ShouldBeFalse();
        };

        Cleanup does = () => ConfigurationManager.RefreshSection("appSettings");
    }
}