using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using eth2validatormonitor.Integration;
using eth2validatormonitor.Integration.ModelV2;
using IO.Swagger.Api;
using IO.Swagger.Client;
using Newtonsoft.Json;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using static eth2validatormonitor.Integration.Format;

namespace eth2validatormonitor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string BaseUrl = "https://beaconcha.in";
        public static string ValidatorPubKey = "";
        readonly ValidatorApi _apiInstance = new ValidatorApi(BaseUrl);
        private Data _data = new Data();
        private PerformanceData _performance = new PerformanceData();
        private List<BalanceHistoryData> _balanceHistory = new List<BalanceHistoryData>();
        private List<AttestationData> _attestationHistory = new List<AttestationData>();

        public MainPage()
        {
            this.InitializeComponent();

            try
            {
                Task.Run(GetValidatorData).Wait();
                Task.Run(GetBalanceHistory).Wait();
                Task.Run(GetValidatorPerformance).Wait();
                Task.Run(GetValidatorOverallScore).Wait();

            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BlockApi.ApiV1BlockSlotAttestationsGet: " + e.Message);
            }
            
        }

        private async void GetBalanceHistory()
        {
            var result = await this._apiInstance.ApiV1ValidatorIndexOrPubkeyBalancehistoryGetAsync(ValidatorPubKey);
            this._balanceHistory = JsonConvert.DeserializeObject<BalanceHistory>(result).Data;
            UpdateUi();
        }

        public async void GetValidatorData()
        {
            var result = await _apiInstance.ApiV1ValidatorIndexOrPubkeyGetAsync(ValidatorPubKey);
            this._data = JsonConvert.DeserializeObject<ValidatorObj>(result).Data;
            UpdateUi();
        }

        public async void GetValidatorPerformance()
        {
            var result = await _apiInstance.ApiV1ValidatorIndexOrPubkeyPerformanceGetAsync(ValidatorPubKey);
            try
            {
                this._performance = JsonConvert.DeserializeObject<Performance>(result).Data;
            }
            catch (Exception e)
            {
                //this handles bad server response they didn't have proper json format when no data is present
            }

            UpdateUi();
        }

        public async void GetValidatorOverallScore()
        {
            var result = await _apiInstance.ApiV1ValidatorIndexOrPubkeyAttestationsGetAsync(ValidatorPubKey);
            this._attestationHistory = JsonConvert.DeserializeObject<AttestationHistory>(result).Data;
            UpdateUi();
        }

        private async void UpdateUi()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {

                GetEthBalance();
                CalculateStatus();
                CalculateIncome();
                CalculateScore();
                var data = this._balanceHistory.ConvertAll(x => new KeyValuePair<DateTime, double>(Format.EpochToTime(x.Epoch), FormatBalance(x.Balance)));
                if (this.balanceChart.Axes.Count == 0 && data.Count > 0)
                {
                    var axis1 = new LinearAxis
                    {
                        Orientation = AxisOrientation.Y,
                        ShowGridLines = true, 
                        Maximum = data.Max(x => x.Value),
                        Minimum = data.Min(x => x.Value),
                        // AxisLabelStyle = 
                    };
                    ;
                    this.balanceChart.Axes.Add(axis1);

                    var axis2 = new LinearAxis
                    {
                        Orientation = AxisOrientation.X,
                        ShowGridLines = true,
                        Maximum = data.Select(x => x.Key).Max().Hour,
                        Minimum = data.Select(x => x.Key).Min().Hour
                    };
                    ;
                    this.balanceChart.Axes.Add(axis2);
                }

                ((LineSeries)this.balanceChart.Series[0]).ItemsSource = data;
            });
        }

        private void GetEthBalance()
        {
           var text = $"Eth Balance \n{FormatBalance(this._data.Balance)} ETH";
           this.balance.Text = text;
        }

        private void CalculateIncome()
        {
            this.income.Text = $"Income \n1 day: {FormatIncome(this._performance.Performance1d)}\n" +
                   $"7 day: {FormatIncome(this._performance.Performance7d)}\n" +
                   $"31 day: {FormatIncome(this._performance.Performance31d)}\n" +
                   $"APR: {Math.Round(FormatIncome(this._performance.Performance7d) * 365 / FormatBalance(this._data.Balance) * 100)}%";
        }

        private void CalculateStatus()
        {
            var state = "";
            if (_data.Activationepoch > _data.Activationeligibilityepoch)
            {
                state =
                    $"pending: About {GetDaysUntils(EpochToTime(_data.Activationepoch - _data.Activationeligibilityepoch))} days left";
            }
            else if (_attestationHistory.Count > 0 && _attestationHistory.GetRange(0, 2).Any(x => x.Status == 0))
            {
                state = "active_offline";
            }
            else if (_attestationHistory.Count > 0 && _attestationHistory.GetRange(0, 2).All(x => x.Status == 1))
            {
                state = "active_online";
            }
            else
            {
                state = "unkown";
            }

            this.status.Text = $"Status \n{state}";
        }

        private void CalculateScore()
        {

            var score = _attestationHistory.Count > 0 ? _attestationHistory.Average(x => x.Status) * 100 : 0;

            //score 
            this.score.Text = $"Score \n{score}%\n";
        }

        private static int GetDaysUntils(DateTime d)
        {
            var nextBirthday = d.AddYears(DateTime.Today.Year - d.Year);
            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            return (nextBirthday - DateTime.Today).Days;
        }
    }
}
