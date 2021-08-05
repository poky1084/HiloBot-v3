using RestSharp;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Hilo_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            
        }
        string token = "";
        string mirror = "https://api.stake.com/graphql";
        bool loggedin = false;
        int run = 0;
        decimal profitall = 0;
        bool pauseonpattern = false;
        bool stopaftermulti = false;
        List<string> list = new List<string>();
        List<string> cardlist = new List<string>();
        bool stopafterwin = false;
        decimal betamount = 0;
        string rowstr = "Start,";
        int gamecount = 0;
        int afterwinsof = 0;
        int afterwinstreaks = 0;
        int afterbetsmade = 0;
        int afterlossmade = 0;
        int afterlosestreaks = 0;
        int seedcount = 0;
        int seedwins = 0;
        int seedlose = 0;
        int skipped = 0; // 0/52
        int guesses = 0; // 0/100
        int wincount = 0;
        int losecount = 0;
        int losestreak = 0;
        int winstreak = 0;
        decimal totalwagered = 0;
        int maxlosestreak = 0;
        int maxwinstreak = 0;
        List<int> highestloss = new List<int>();
        List<int> highestwin = new List<int>();
        List<decimal> balances = new List<decimal>();
        decimal balance = 0;
        int currencyindex = 0;
        private void Application_ApplicationExit(object sender, EventArgs e)
        { 
            
            Properties.Settings.Default.Save();

        }

        private bool RegexPattern(string pattern)
        {
            return (System.Text.RegularExpressions.Regex.IsMatch(pattern, "^[0-5]+(,[0-5]+)*$"));
        }
        private string CardLayout(string rank, string suit)
        {

            switch (suit)
            {
                case "H":
                    return rank + "\u2661";
                case "C":
                    return rank + "\u2663";
                case "D":
                    return rank + "\u2662";
                case "S":
                    return rank + "\u2660";
                default:
                    return "Nosuit";
            }
        }
        Color CardColor(string suit)
        {

            switch (suit)
            {
                case "H":
                    return Color.Red;
                case "C":
                    return Color.Black;
                case "D":
                    return Color.Red;
                case "S":
                    return Color.Black;
                default:
                    return Color.Black;
            }
        }
        private void UpdateStats()
        {
            balances[IndexCurrency()] = balance + profitall;
            //balance = balances[IndexCurrency()];
            labelProfit.Text = profitall.ToString("0.00000000").Replace("-", "−") + " " + CurrencyList.Text;
            labelBalance.Text = balances[IndexCurrency()].ToString("0.00000000") + " " + CurrencyList.Text;
            labelWager.Text = totalwagered.ToString("0.00000000") + " " + CurrencyList.Text;
            labelWins.Text = wincount.ToString();
            labelWinstreak.Text = winstreak.ToString() + " | Highest "+maxwinstreak;
            labelLosses.Text = losecount.ToString();
            labelLosestreak.Text = losestreak.ToString() + " | Highest " +maxlosestreak;

            mainBalance.Text = balances[IndexCurrency()].ToString("0.00000000") + " " + CurrencyList.Text;
            mainProfit.Text = profitall.ToString("0.00000000").Replace("-", "−") + " " + CurrencyList.Text;
            mainWager.Text = totalwagered.ToString("0.00000000") + " " + CurrencyList.Text;
        }
        private void ResetStats()
        {
            balance = balances[IndexCurrency()];
            profitall = 0;
            totalwagered = 0;
            wincount = 0;
            losecount = 0;
            losestreak = 0;
            winstreak = 0;
            highestwin.Clear();
            highestloss.Clear();
            maxlosestreak = 0;
            maxwinstreak = 0;
            UpdateStats();
        }
        private void AddCard(Data response)
        {
            if (response.data.hiloNext != null)
            {


                int nexts = response.data.hiloNext.state.rounds.Count - 1;
                list.Add(response.data.hiloNext.state.rounds[nexts].card.rank);
                label2.Text = response.data.hiloNext.state.rounds[nexts].payoutMultiplier.ToString("0.##").Replace(",", ".") + "x";
                                
                //var carditem = new ListViewItem(CardLayout(response.data.hiloNext.state.rounds[nexts].card.rank, response.data.hiloNext.state.rounds[nexts].card.suit));                
                //listView1.Items.Add(carditem);
                //listView1.Items[listView1.Items.Count - 1].EnsureVisible();

                string card = CardLayout(response.data.hiloNext.state.rounds[nexts].card.rank, response.data.hiloNext.state.rounds[nexts].card.suit);
                listBox1.Items.Add(card);
                listBox1.TopIndex = listBox1.Items.Count - 1;


            }
        }
        private void AddStartCard(Data response)
        {
            if (response.data.hiloBet != null)
            {
                list.Add(response.data.hiloBet.state.startCard.rank);

                string startcard = CardLayout(response.data.hiloBet.state.startCard.rank, response.data.hiloBet.state.startCard.suit);
                listBox1.Items.Add(startcard);

            }
        }
        private void ClearCards()
        {

            button2.Enabled = true;
            guesses = 0;
            skipped = 0;
            rowstr = "Start,";
            list.Clear();
            label2.Text = "0.00x";
            //listView1.Columns.Clear();
            listBox1.Items.Clear();
        }
        private void EditStatus(string text)
        {
            label3.Text = "Status: " + text;


        }
        private void AddLog(string text)
        {
            //label3.Text = "Status: " + text;
            string[] row = { DateTime.Now.ToString("HH:mm:ss"), text };
            var logitem = new ListViewItem(row);
            logitem.Font = new Font("Consolas", 10f);
            LogView2.Items.Insert(0, logitem);

        }
        private void BetList(Data response)
        {
            if (response.data.hiloCashout != null && response.data != null)
            {
                decimal betamount = response.data.hiloCashout.amount;
                decimal profit = response.data.hiloCashout.payout - response.data.hiloCashout.amount;
                double multiplier = response.data.hiloCashout.payoutMultiplier;
                string cards = string.Join(",", list);
                string[] row = { gamecount.ToString(), profit.ToString("0.00000000"), betamount.ToString("0.00000000"), multiplier.ToString("0.00") + "x", cards };
                var betitem = new ListViewItem(row);
                betitem.Font = new Font("Consolas", 10f);
                if(multiplier > 0)
                {
                    betitem.BackColor = Color.LightGreen;
                }
                else
                {
                    betitem.BackColor = Color.White;
                }
                listView4.Items.Insert(0, betitem);

            }
            else if(response.data.hiloNext != null)
            {
                decimal betamount = response.data.hiloNext.amount;
                decimal profit = -response.data.hiloNext.amount;
                double multiplier = response.data.hiloNext.state.rounds[response.data.hiloNext.state.rounds.Count - 1].payoutMultiplier;
                string cards = string.Join(",", list).Replace(",", " ");
                string[] row = { gamecount.ToString(), profit.ToString("0.00000000"), betamount.ToString("0.00000000"), multiplier.ToString("0.00") + "x", cards };
                var betitem = new ListViewItem(row);
                betitem.Font = new Font("Consolas", 10f);
                listView4.Items.Insert(0, betitem);
            }
        }
        private void SetToken(string apikey)
        {
            token = apikey;
        }
        private async void LogIn()
        {
            var url = mirror;
            var request = new RestRequest(Method.POST);
            var client = new RestClient(url);
            Payload payload = new Payload();
            payload.operationName = "initialUserRequest";
            payload.variables = new betobj() { };
            payload.query = "query initialUserRequest {\n  user {\n    ...UserAuth\n    __typename\n  }\n}\n\nfragment UserAuth on User {\n  id\n  name\n  email\n  hasPhoneNumberVerified\n  hasEmailVerified\n  hasPassword\n  intercomHash\n  createdAt\n  hasTfaEnabled\n  mixpanelId\n  hasOauth\n  isKycBasicRequired\n  isKycExtendedRequired\n  isKycFullRequired\n  kycBasic {\n    id\n    status\n    __typename\n  }\n  kycExtended {\n    id\n    status\n    __typename\n  }\n  kycFull {\n    id\n    status\n    __typename\n  }\n  flags {\n    flag\n    __typename\n  }\n  roles {\n    name\n    __typename\n  }\n  balances {\n    ...UserBalanceFragment\n    __typename\n  }\n  activeClientSeed {\n    id\n    seed\n    __typename\n  }\n  previousServerSeed {\n    id\n    seed\n    __typename\n  }\n  activeServerSeed {\n    id\n    seedHash\n    nextSeedHash\n    nonce\n    blocked\n    __typename\n  }\n  __typename\n}\n\nfragment UserBalanceFragment on UserBalance {\n  available {\n    amount\n    currency\n    __typename\n  }\n  vault {\n    amount\n    currency\n    __typename\n  }\n  __typename\n}\n";
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-access-token", token);

            request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);

            var restResponse =
                await client.ExecuteAsync(request);

            // Will output the HTML contents of the requested page
            //Debug.WriteLine(restResponse.Content);
            ActiveData response = JsonConvert.DeserializeObject<ActiveData>(restResponse.Content, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    EditStatus("Bad response from server");
                    args.ErrorContext.Handled = true;
                },

            });
            //Debug.WriteLine(restResponse.Content);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {

                if (response.errors == null)
                {


                    if (response.data.user != null)
                    {
                        this.Text += " - " + response.data.user.name;
                        textBox1.Enabled = false;
                        button1.Enabled = false;
                        
                        
                        EditStatus("Logged in");
                        AddLog("Logged in");
                        loggedin = true;
                        SetBalances(response);
                        balance = balances[IndexCurrency()];
                        UpdateStats();
                        activeHiloBet();

                    }
                }
                else
                {

                    if (response.errors[0].errorType == "invalidSession")
                    {
                        AddLog("Error logging in (Wrong api key)");
                        textBox1.Enabled = true;
                        button1.Enabled = true;
                        loggedin = false;
                    }
                    else
                    {
                        EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");

                    }


                }
            }
            else
            {
                EditStatus("Error logging in. (Code:"+ restResponse.StatusCode+")");
                textBox1.Enabled = true;
                button1.Enabled = true;
                loggedin = false;
            }
        }
        private void SetBalances(ActiveData response)
        {
            
            if (response.data.user != null)
            {
                for(var i = 0; i < response.data.user.balances.Count; i++)
                {
                    balances.Add(response.data.user.balances[i].available.amount);
                }
            }
        }
        private async void activeHiloBet()
        {
            var url = mirror;
            var request = new RestRequest(Method.POST);
            var client = new RestClient(url);
            Payload payload = new Payload();
            payload.operationName = "HiloActiveBet";
            payload.variables = new betobj() { };
            payload.query = "query HiloActiveBet {\n  user {\n    id\n    activeCasinoBet(game: hilo) {\n      ...CasinoBetFragment\n      state {\n        ...HiloStateFragment\n        __typename\n      }\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment CasinoBetFragment on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment HiloStateFragment on CasinoGameHilo {\n  startCard {\n    suit\n    rank\n    __typename\n  }\n  rounds {\n    card {\n      suit\n      rank\n      __typename\n    }\n    guess\n    payoutMultiplier\n    __typename\n  }\n  __typename\n}\n";
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-access-token", token);

            request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);

            var restResponse =
                await client.ExecuteAsync(request);

            // Will output the HTML contents of the requested page
            //Debug.WriteLine(restResponse.Content);
            ActiveData response = JsonConvert.DeserializeObject<ActiveData>(restResponse.Content, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    EditStatus("Bad response from server");
                    args.ErrorContext.Handled = true;
                },

            });
            //Debug.WriteLine(restResponse.Content);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                if (response.errors == null)
                {
                    if (response.data.user.activeCasinoBet != null)
                    {
                        list.Add(response.data.user.activeCasinoBet.state.startCard.rank);
                        string startcard = CardLayout(response.data.user.activeCasinoBet.state.startCard.rank, response.data.user.activeCasinoBet.state.startCard.suit);
                        listBox1.Items.Add(startcard);
                        

                        for (var i = 0; i < response.data.user.activeCasinoBet.state.rounds.Count; i++)
                        {
                            int nexts = i;
                            list.Add(response.data.user.activeCasinoBet.state.rounds[nexts].card.rank);
                            label2.Text = response.data.user.activeCasinoBet.state.rounds[nexts].payoutMultiplier.ToString("0.##").Replace(",", ".") + "x";
                            string card = CardLayout(response.data.user.activeCasinoBet.state.rounds[nexts].card.rank, response.data.user.activeCasinoBet.state.rounds[nexts].card.suit);
                            listBox1.Items.Add(card);
                            listBox1.TopIndex = listBox1.Items.Count - 1;
                            
                            

                        }
                        CurrencyList.Text = response.data.user.activeCasinoBet.currency;


                    }
                }
                else
                {
                    EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");
                }
            }
            else
            {
                EditStatus("Error getting Active game. (Code:" + restResponse.StatusCode + ")");
            }

        }

        private async void HiloBet()
        {
            if (DelayBet.Value > 0)
            {
                await Task.Delay((int)DelayBet.Value);
            }
            if(StopLimit.Value > 0 && gamecount >= StopLimit.Value)
            {
                run = 0;
                
                AddLog("Auto stopped");
                EditStatus("Auto stopped. (Stop after games)");
                gamecount = 0;
            }
            if (run == 1)
            {
                var url = mirror;
                var request = new RestRequest(Method.POST);
                var client = new RestClient(url);
                Payload payload = new Payload();
                payload.operationName = "HiloBet";
                payload.variables = new betobj()
                {
                    currency = CurrencyList.Text,
                    amount = betamount,
                    startCard = new Card()
                    {
                        suit = suitBox.Text,
                        rank = rankBox.Text
                    }

                };
                payload.query = "mutation HiloBet($amount: Float!, $currency: CurrencyEnum!, $startCard: HiloBetStartCardInput!) {\n  hiloBet(amount: $amount, currency: $currency, startCard: $startCard) {\n    ...CasinoBetFragment\n    state {\n      ...HiloStateFragment\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment CasinoBetFragment on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment HiloStateFragment on CasinoGameHilo {\n  startCard {\n    suit\n    rank\n    __typename\n  }\n  rounds {\n    card {\n      suit\n      rank\n      __typename\n    }\n    guess\n    payoutMultiplier\n    __typename\n  }\n  __typename\n}\n";
                //request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", token);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
                //request.AddJsonBody(payload);
                //IRestResponse response = client.Execute(request);

                var restResponse =
                    await client.ExecuteAsync(request);

                // Will output the HTML contents of the requested page
                //Debug.WriteLine(restResponse.Content);
                Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content, new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        EditStatus("Bad response from server");
                        args.ErrorContext.Handled = true;
                        //HiloBet();
                    },

                });
                //Debug.WriteLine(restResponse.Content);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (response.errors == null)
                    {

                        if (response.data.hiloBet != null)
                        {


                            AddStartCard(response);
                            gamecount++;
                            seedcount++;
                            afterbetsmade++;

                            profitall -= response.data.hiloBet.amount;
                            UpdateStats();
                            totalwagered += response.data.hiloBet.amount;
                            var guess = Pattern(list.Count - 1);
                            HiloNext(guess);
                        }
                        else
                        {
                            EditStatus("No response data");
                        }

                    }
                    else
                    {
                        
                        if (response.errors[0].errorType == "insufficientBalance")
                        {
                            ResetBaseAfterStop();
                            run = 0;
                            AddLog("Auto stopped");
                            EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");
                            patternBox.Enabled = true;
                        }
                        else if (response.errors[0].errorType == "existingGame")
                        {
                            EditStatus("There is an active hilo game. Use manual bet");
                            var guess = Pattern(list.Count - 1);
                            HiloNext(guess);
                        }
                        else if (response.errors[0].errorType == "stringPatternBase")
                        {
                            EditStatus("Invalid Startcard (rank/suit)");
                            run = 0;
                            patternBox.Enabled = true;
                        }
                        else
                        {
                            EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");
                        }
                    }
                }
                else
                {
                    EditStatus("HiloBet: Retrying in 2 sec. (Code:" + restResponse.StatusCode + ")");

                    await Task.Delay(2000);
                    HiloBet();
                }
            }
            else
            {

                patternBox.Enabled = true;

            }

        }

        private async void HiloNext(string guessed)
        {
            if (DelayGuess.Value > 0)
            {
                await Task.Delay((int)DelayGuess.Value);
            }
            if (run == 1)
            {
                var url = mirror;                
                var request = new RestRequest(Method.POST);
                var client = new RestClient(url);
                Payload payload = new Payload();
                payload.operationName = "HiloNext";
                payload.variables = new betobj()
                {
                    guess = guessed
                };
                payload.query = "mutation HiloNext($guess: CasinoGameHiloGuessEnum!) {\n  hiloNext(guess: $guess) {\n    ...CasinoBetFragment\n    state {\n      ...HiloStateFragment\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment CasinoBetFragment on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment HiloStateFragment on CasinoGameHilo {\n  startCard {\n    suit\n    rank\n    __typename\n  }\n  rounds {\n    card {\n      suit\n      rank\n      __typename\n    }\n    guess\n    payoutMultiplier\n    __typename\n  }\n  __typename\n}\n";

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-access-token", token);

                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
                //request.AddJsonBody(payload);
                //IRestResponse response = client.Execute(request);

                var restResponse =
                    await client.ExecuteAsync(request);

                // Will output the HTML contents of the requested page
                //Debug.WriteLine(restResponse.Content);
                Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content, new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        EditStatus("Bad response from server");
                        args.ErrorContext.Handled = true;
                        //var guess = Pattern(list.Count - 1);
                        //HiloNext(guess);

                    },

                });
                //Debug.WriteLine(restResponse.Content);
                //button2.Enabled = true;
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {

                    if (response.errors == null)
                    {
                        if (response.data.hiloNext != null)
                        {



                            AddCard(response);

                            double payoutMulti = response.data.hiloNext.state.rounds[response.data.hiloNext.state.rounds.Count - 1].payoutMultiplier;
                            if (guessed == "skip")
                            {
                                skipped++;
                            }
                            else
                            {
                                guesses++;
                            }
                            if (payoutMulti > 0)
                            {
                                if (payoutMulti >= (double)PauseMulti.Value && PauseMulticheckBox.Checked == true)
                                {
                                    run = 0;
                                    patternBox.Enabled = true;
                                    ResetBaseAfterStop();
                                    var text = "Paused (Pause on Multiplier)";
                                    AddLog(text);
                                    EditStatus(text);
                                }
                                else if (stopaftermulti && payoutMulti >= (double)StopAutoValue.Value)
                                {
                                    run = 0;
                                    AddLog("Auto stopped");

                                    patternBox.Enabled = true;
                                    ResetBaseAfterStop();
                                    HiloCashout();
                                }
                                else
                                {



                                    if (payoutMulti >= (double)AutoCashout.Value && AutoCashout.Value > 0 && CashoutcheckBox2.Checked == true)
                                    {

                                        HiloCashout();

                                    }
                                    else
                                    {



                                        if (skipped >= 52)
                                        {

                                        }
                                        if (list.Count > patternBox.Text.Trim().Split(',').Length)
                                        {

                                            if (!pauseonpattern)
                                            {

                                                HiloCashout();
                                            }
                                            else
                                            {
                                                run = 0;


                                                patternBox.Enabled = true;
                                                ResetBaseAfterStop();
                                                var text = "Paused (Pause on pattern)";
                                                AddLog(text);
                                                EditStatus(text);
                                            }

                                        }
                                        else
                                        {



                                            var guess = Pattern(list.Count - 1);
                                            HiloNext(guess);
                                        }
                                    }
                                }


                            }
                            else
                            {
                                losecount++;
                                losestreak++;
                                highestloss.Add(losestreak);
                                maxlosestreak = highestloss.Max();
                                highestloss.Clear();
                                highestloss.Add(maxlosestreak);
                                winstreak = 0;
                                seedlose++;
                                afterlossmade++;
                                afterlosestreaks = losestreak;
                                BetList(response);
                                ClearCards();
                                //profitall -= response.data.hiloNext.amount;
                                UpdateStats();
                                if (IncrementLoss.Value > 1)
                                {
                                    //betamount *= IncrementLoss.Value;
                                }
                                if (betIncrement.Value > 1 && afterbetsmade >= afterbetsOf.Value && afterbetsOf.Value > 0)
                                {
                                    afterbetsmade = 0;
                                    betamount *= betIncrement.Value;
                                }
                                if (lossesIncrement.Value > 1 && afterlossmade >= afterlossesOf.Value && afterlossesOf.Value > 0)
                                {
                                    afterlossmade = 0;
                                    betamount *= lossesIncrement.Value;
                                }
                                if(losesteakIncrement.Value > 1 && afterlosestreaks >= afterlosetreakOf.Value && afterlosetreakOf.Value > 0)
                                {
                                    afterlosestreaks = 0;
                                    betamount *= losesteakIncrement.Value;
                                }
                                if (SeedcheckBox.Checked == true && IsSeedRotate())
                                {
                                    await RotateSeed();
                                }
                                HiloBet();
                            }
                        }
                        else
                        {
                            EditStatus("No response data");
                        }
                    }
                    else
                    {
                        if (response.errors[0].errorType == "notFound")
                        {
                           
                            ClearCards();
                        }
                        else if (response.errors[0].errorType == "hiloInvalidGuess")
                        {

                        }
                        else if (response.errors[0].errorType == "hiloMaxSkip")
                        {
                            var guess = Pattern(list.Count - 1);
                            HiloNext(guess);
                        }
                        EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");

                    }
                }
                else
                {
                    EditStatus("HiloGuess: Retrying in 1 sec. (Code:" + restResponse.StatusCode + ")");

                    await Task.Delay(1000);
                    var guess = Pattern(list.Count - 1);
                    HiloNext(guess);
                }
            }
            else
            {
                AddLog("Auto/Manual stopped.");

                patternBox.Enabled = true;

            }


        }
        private async void HiloCashout()
        {

            var url = mirror;
            var request = new RestRequest(Method.POST);
            var client = new RestClient(url);
            Payload payload = new Payload();
            payload.operationName = "HiloCashout";
            payload.variables = new betobj()
            {
                identifier = "786247d5bddc9cde2f0f"
            };
            payload.query = "mutation HiloCashout($identifier: String!) {\n  hiloCashout(identifier: $identifier) {\n    ...CasinoBetFragment\n    state {\n      ...HiloStateFragment\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment CasinoBetFragment on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment HiloStateFragment on CasinoGameHilo {\n  startCard {\n    suit\n    rank\n    __typename\n  }\n  rounds {\n    card {\n      suit\n      rank\n      __typename\n    }\n    guess\n    payoutMultiplier\n    __typename\n  }\n  __typename\n}\n";
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-access-token", token);

            request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);

            var restResponse =
                await client.ExecuteAsync(request);

            // Will output the HTML contents of the requested page
            //Debug.WriteLine(restResponse.Content);
            Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    EditStatus("Bad response from server");
                    args.ErrorContext.Handled = true;
                    //HiloCashout();

                },

            });
            //Debug.WriteLine(restResponse.Content);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {

                if (response.errors == null)
                {
                    if (response.data.hiloCashout != null)
                    {

                        wincount++;
                        seedwins++;
                        winstreak++;
                        highestwin.Add(winstreak);
                        maxwinstreak = highestwin.Max();
                        highestwin.Clear();
                        highestwin.Add(maxwinstreak);
                        losestreak = 0;
                        afterwinsof++;
                        afterwinstreaks = winstreak;
                        profitall += response.data.hiloCashout.payout;
                        UpdateStats();
                        if (betIncrement.Value > 1 && afterbetsmade >= afterbetsOf.Value && afterbetsOf.Value > 0)
                        {
                            afterbetsmade = 0;
                            betamount *= betIncrement.Value;
                        }
                        if (ResettoBaseWin.Checked == true && afterwinsof >= resetBasewinsOf.Value)
                        {

                            afterwinsof = 0;
                            betamount = BaseBetAmount.Value;

                        }
                        if(ResetBasewinstreakcheckBox2.Checked == true && afterwinstreaks >= resetBasewinstreakOf.Value)
                        {
                            afterwinstreaks = 0;
                            betamount = BaseBetAmount.Value;
                        }

                        BetList(response);
                        ClearCards();
                        if (stopafterwin)
                        {
                            run = 0;
                            AddLog("Auto stopped");
                            ResetBaseAfterStop();
                            patternBox.Enabled = true;
                        }
                        else
                        {
                            if(SeedcheckBox.Checked == true && IsSeedRotate()) 
                            {
                                await RotateSeed();
                            }
                            
                            HiloBet();
                        }
                    }
                    else
                    {
                        EditStatus("No response data");
                    }

                }
                else
                {
                    if (response.errors[0].errorType == "hiloNoRoundsPlayed")
                    {

                    }
                    EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");

                }
            }
            else
            {
                EditStatus("HiloCashout: Retrying in 2 sec. (Code:" + restResponse.StatusCode + ")");

                await Task.Delay(2000);
                HiloCashout();
            }

        }

        private bool IsSeedRotate()
        {
            if (seedcount >= Seedxbets.Value && Seedxbets.Value > 0)
            {
                seedcount = 0;
                return true;
            }
            if (seedwins >= SeedxWin.Value && SeedxWin.Value > 0)
            {
                seedwins = 0;
                return true;
            }
            if (seedlose >= SeedxLose.Value && SeedxLose.Value > 0)
            {
                seedlose = 0;
                return true;
            }
            return false;
        }
        
        public string RandomString(int length)
        {
            if(SeedBox3.TextLength > 0)
            {
                return SeedBox3.Text;
            }
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SetToken(textBox1.Text);
            LogIn();
            button1.Enabled = false;



        }
        private void ResetBaseAfterStop()
        {
            if (ResetBaseStop.Checked == true)
            {
                betamount = BaseBetAmount.Value;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(run == 1)
            {
                AddLog("Auto stopped");
            }
            run = 0;
            ResetBaseAfterStop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0 && run == 0 && loggedin == true)
            {
                run = 1;
                AddLog("Auto started");
                ResetBaseAfterStop();
                patternBox.Enabled = false;
                HiloBet();
            }
            else
            {
                if (loggedin == false)
                {
                    EditStatus("Can't start auto. (Not logged in)");
                }
                else
                {
                    EditStatus("Can't start auto (Active game). Play manual or Cashout");
                }


            }
        }



        private string isHiLow(string lastcard)
        {
            string str = "1";
            try
            {
                string[] strArray = new string[13]
                {
                    "A",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "J",
                    "Q",
                    "K"
                };
                int[] numArray = new int[13]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13
                };
                int num1 = numArray[strArray.ToList().IndexOf(lastcard)];
                int num2 = numArray[6];
                if (num1 > num2)
                    str = "0";
                else if (num1 < num2)
                    str = "1";
            }
            catch (Exception ex)
            {

            }
            return str;
        }
        private string Pattern(int index)
        {
            string guess = "skip";
            string[] strArray = patternBox.Text.Trim().Split(',');

            switch (Int32.Parse(strArray[index]))
            {
                case 0:
                    guess = "lowerEqual";
                    if (list[list.Count - 1] == "K")
                    {
                        guess = "lower";
                        return guess;
                    }
                    if (list[list.Count - 1] == "A")
                    {
                        guess = "equal";
                        return guess;
                    }
                    return guess;
                case 1:
                    guess = "higherEqual";
                    if (list[list.Count - 1] == "K")
                    {
                        guess = "equal";
                        return guess;
                    }
                    if (list[list.Count - 1] == "A")
                    {
                        guess = "higher";
                        return guess;
                    }
                    return guess;
                case 2:
                    guess = "equal";
                    return guess;
                case 3:
                    string[] vote = { "equal", "lower", "higher", "higherEqual", "lowerEqual" };
                    string[] voteA = { "equal", "higher" };
                    string[] voteK = { "equal", "lower" };
                    Random rnd = new Random();
                    guess = vote[rnd.Next(vote.Count())];
                    if (list[list.Count - 1] == "A")
                    {
                        guess = voteA[rnd.Next(voteA.Count())];
                        return guess;
                    }
                    if (list[list.Count - 1] == "K")
                    {
                        guess = voteK[rnd.Next(voteK.Count())];
                        return guess;
                    }
                    return guess;
                case 4:
                    guess = "higherEqual";
                    if (Int32.Parse(isHiLow(list[list.Count - 1])) == 1)
                    {
                        guess = "lowerEqual";
                        if (list[list.Count - 1] == "A")
                        {
                            guess = "equal";
                            return guess;
                        }
                        if (list[list.Count - 1] == "K")
                        {
                            guess = "lower";
                            return guess;
                        }
                        return guess;
                    }
                    if (list[list.Count - 1] == "A")
                        guess = "higher";
                    else if (list[list.Count - 1] == "K")
                        guess = "equal";
                    return guess;
                case 5:
                    guess = "lowerEqual";
                    if (Int32.Parse(isHiLow(list[list.Count - 1])) == 1)
                    {
                        guess = "higherEqual";
                        if (list[list.Count - 1] == "A")
                        {
                            guess = "higher";
                            return guess;
                        }
                        if (list[list.Count - 1] == "K")
                        {
                            guess = "lower";
                            return guess;
                        }
                        return guess;
                    }
                    if (list[list.Count - 1] == "A")
                        guess = "higher";
                    else if (list[list.Count - 1] == "K")
                        guess = "lower";
                    return guess;
                default:
                    return guess;
            }


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["ManualPage"])//your specific tabname
            {

            }
            else
            {

            }
        }

        private void ManualHigh_Click(object sender, EventArgs e)
        {
            if (list.Count > 0 && run == 0)
            {


                if (list[list.Count - 1] == "A")
                {
                    ManualNext("higher");
                }
                else if (list[list.Count - 1] != "K")
                {
                    ManualNext("higherEqual");
                }
            }

        }

        private void ManualLow_Click(object sender, EventArgs e)
        {
            if (list.Count > 0 && run == 0)
            {
                if (list[list.Count - 1] == "K")
                {
                    ManualNext("lower");
                }
                else if (list[list.Count - 1] != "A")
                {
                    ManualNext("lowerEqual");
                }
            }
        }

        private void ManualSkip_Click(object sender, EventArgs e)
        {
            if (list.Count > 0 && run == 0)
            {
                ManualNext("skip");
            }

        }

        private void ManualCashout_btn_Click(object sender, EventArgs e)
        {
            if (list.Count > 0 && run == 0)
            {
                ManualCashout();
            }
        }

        private void ManualStart_Click(object sender, EventArgs e)
        {
            if (run == 0 && listBox1.Items.Count == 0 && loggedin == true)
            {
                ManualBet();
            }

        }
        private void ManualEqual_btn_Click(object sender, EventArgs e)
        {
            if (list.Count > 0 && run == 0)
            {
                ManualNext("equal");
            }

        }
        private async void ManualBet()
        {

            var url = mirror;
            var request = new RestRequest(Method.POST);
            var client = new RestClient(url);
            Payload payload = new Payload();
            payload.operationName = "HiloBet";
            payload.variables = new betobj()
            {
                currency = CurrencyList.Text,
                amount = betamount,
                startCard = new Card()
                {
                    suit = suitBox.Text,
                    rank = rankBox.Text
                }

            };
            payload.query = "mutation HiloBet($amount: Float!, $currency: CurrencyEnum!, $startCard: HiloBetStartCardInput!) {\n  hiloBet(amount: $amount, currency: $currency, startCard: $startCard) {\n    ...CasinoBetFragment\n    state {\n      ...HiloStateFragment\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment CasinoBetFragment on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment HiloStateFragment on CasinoGameHilo {\n  startCard {\n    suit\n    rank\n    __typename\n  }\n  rounds {\n    card {\n      suit\n      rank\n      __typename\n    }\n    guess\n    payoutMultiplier\n    __typename\n  }\n  __typename\n}\n";
            //request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-access-token", token);

            request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);

            var restResponse =
                await client.ExecuteAsync(request);

            // Will output the HTML contents of the requested page
            //Debug.WriteLine(restResponse.Content);
            Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    EditStatus("Bad response from server");
                    args.ErrorContext.Handled = true;
                },

            });
            //Debug.WriteLine(restResponse.Content);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                if (response.errors == null)
                {

                    if(response.data.hiloBet != null)
                    {
                        AddLog("Manual started");
                        ClearCards();
                        AddStartCard(response);
                        profitall -= response.data.hiloBet.amount;
                        gamecount++;
                        seedcount++;
                    }
                    else
                    {
                        EditStatus("No response data");
                    }


                }
                else
                {
                    EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");

                }
            }
            else
            {
                EditStatus("Bet failed, try again. (Code:" + restResponse.StatusCode + ")");            
            }
        }
        private async void ManualNext(string guessed)
        {

            var url = mirror;
            var request = new RestRequest(Method.POST);
            var client = new RestClient(url);
            Payload payload = new Payload();
            payload.operationName = "HiloNext";
            payload.variables = new betobj()
            {
                guess = guessed
            };
            payload.query = "mutation HiloNext($guess: CasinoGameHiloGuessEnum!) {\n  hiloNext(guess: $guess) {\n    ...CasinoBetFragment\n    state {\n      ...HiloStateFragment\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment CasinoBetFragment on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment HiloStateFragment on CasinoGameHilo {\n  startCard {\n    suit\n    rank\n    __typename\n  }\n  rounds {\n    card {\n      suit\n      rank\n      __typename\n    }\n    guess\n    payoutMultiplier\n    __typename\n  }\n  __typename\n}\n";

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-access-token", token);

            request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);

            var restResponse =
                await client.ExecuteAsync(request);

            // Will output the HTML contents of the requested page
            //Debug.WriteLine(restResponse.Content);
            Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    EditStatus("Bad response from server");
                    args.ErrorContext.Handled = true;
                },

            });
            //Debug.WriteLine(restResponse.Content);
            //button2.Enabled = true;
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {

                if (response.errors == null)
                {
                    if (response.data.hiloNext != null)
                    {

                        AddCard(response);
                        double payoutMulti = response.data.hiloNext.state.rounds[response.data.hiloNext.state.rounds.Count - 1].payoutMultiplier;
                        if (payoutMulti > 0)
                        {




                            if (guessed == "skip")
                            {
                                skipped++;
                            }
                        }
                        else
                        {
                            BetList(response);
                            ClearCards();
                            losecount++;
                            winstreak = 0;
                            losestreak++;
                            highestloss.Add(losestreak);
                            maxlosestreak = highestloss.Max();
                            highestloss.Clear();
                            highestloss.Add(maxlosestreak);
                            //profitall -= response.data.hiloNext.amount;
                            UpdateStats();
                            patternBox.Enabled = true;
                        }
                                
                    }
                    else
                    {
                        EditStatus("No response data");

                    }
                }
                else
                {
                    if (response.errors[0].errorType == "notFound")
                    {

                        ClearCards();
                    }
                    EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");

                }
            }
            else
            {
                EditStatus("Guess failed, try again. (Code:" + restResponse.StatusCode + ")");

            }


        }
        private async void ManualCashout()
        {

            var url = mirror;
            var request = new RestRequest(Method.POST);
            var client = new RestClient(url);
            Payload payload = new Payload();
            payload.operationName = "HiloCashout";
            payload.variables = new betobj()
            {
                identifier = "786247d5bddc9cde2f0f"
            };
            payload.query = "mutation HiloCashout($identifier: String!) {\n  hiloCashout(identifier: $identifier) {\n    ...CasinoBetFragment\n    state {\n      ...HiloStateFragment\n      __typename\n    }\n    __typename\n  }\n}\n\nfragment CasinoBetFragment on CasinoBet {\n  id\n  active\n  payoutMultiplier\n  amountMultiplier\n  amount\n  payout\n  updatedAt\n  currency\n  game\n  user {\n    id\n    name\n    __typename\n  }\n  __typename\n}\n\nfragment HiloStateFragment on CasinoGameHilo {\n  startCard {\n    suit\n    rank\n    __typename\n  }\n  rounds {\n    card {\n      suit\n      rank\n      __typename\n    }\n    guess\n    payoutMultiplier\n    __typename\n  }\n  __typename\n}\n";
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-access-token", token);

            request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);

            var restResponse =
                await client.ExecuteAsync(request);

            // Will output the HTML contents of the requested page
            //Debug.WriteLine(restResponse.Content);
            Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    EditStatus("Bad response from server");
                    args.ErrorContext.Handled = true;
                },

            });
            //Debug.WriteLine(restResponse.Content);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                if (response.errors == null)
                {

                    if (response.data.hiloCashout != null)
                    {

                        AddLog("Manual Cashout");
                        BetList(response);
                        ClearCards();
                        wincount++;
                        losestreak = 0;
                        winstreak++;
                        highestwin.Add(losestreak);
                        maxwinstreak = highestwin.Max();
                        highestwin.Clear();
                        highestwin.Add(maxwinstreak);
                        profitall += response.data.hiloCashout.payout;
                        UpdateStats();
                        betamount = BaseBetAmount.Value;

                        patternBox.Enabled = true;
   
                    }
                    else
                    {
                        EditStatus("No response data");
                    }
                }
                else
                {
                    if (response.errors[0].errorType == "hiloNoRoundsPlayed")
                    {
                        EditStatus("Before cashout, click Higher, Lower or Equal");
                    }
                    else
                    {
                        EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");
                    }

                }
            }
            else
            {
                EditStatus("Cashout failed, try again. (Code:" + restResponse.StatusCode + ")");

            }
        }


        private async Task RotateSeed()
        {

            var url = mirror;
            var request = new RestRequest(Method.POST);
            var client = new RestClient(url);
            Payload payload = new Payload();
            payload.operationName = "RotateSeedPair";
            payload.variables = new betobj()
            {
                seed = RandomString(10)
            };
            payload.query = "mutation RotateSeedPair($seed: String!) {\n  rotateSeedPair(seed: $seed) {\n    clientSeed {\n      user {\n        id\n        activeClientSeed {\n          id\n          seed\n          __typename\n        }\n        activeServerSeed {\n          id\n          nonce\n          seedHash\n          nextSeedHash\n          __typename\n        }\n        __typename\n      }\n      __typename\n    }\n    __typename\n  }\n}\n";
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-access-token", token);

            request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);

            var restResponse =
                await client.ExecuteAsync(request);

            // Will output the HTML contents of the requested page
            //Debug.WriteLine(restResponse.Content);
            Data response = JsonConvert.DeserializeObject<Data>(restResponse.Content, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    EditStatus("Bad response from server");
                    args.ErrorContext.Handled = true;
                },

            });
            //Debug.WriteLine(restResponse.Content);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                if (response.errors == null)
                {

                    if (response.data.rotateSeedPair != null)
                    {

                        AddLog("Seed changed");
                        

                    }
                    else
                    {
                        EditStatus("RotateSeed: No response data");
                    }
                }
                else
                {
  
                    EditStatus(response.errors[0].message + " (" + response.errors[0].errorType + ")");

                }
            }
            else
            {
                EditStatus("Change seed failed. (Code:" + restResponse.StatusCode + ")");

            }
        }

        private bool PatternMatch(int[] arr)
        {
            int res = 6;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > res)
                {
                    return false;
                }
            }
            return true;
        }
        private void patternBox_TextChanged(object sender, EventArgs e)
        {
            if (RegexPattern(patternBox.Text))
            {
                Properties.Settings.Default.pattern = patternBox.Text;
                button3.Enabled = true;
                button2.Enabled = true;
                // string[] strArray = patternBox.Text.Trim().Split(',');
                //int[] myInts = Array.ConvertAll(strArray, s => int.Parse(s));
            }
            else
            {
                
                EditStatus("Pattern numbers only (0-5)");
                button3.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void BaseBetAmount_ValueChanged(object sender, EventArgs e)
        {
            betamount = BaseBetAmount.Value;
            Properties.Settings.Default.basebet = BaseBetAmount.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkBox1 = checkBox1.Checked;
            if (checkBox1.Checked == true)
            {
                pauseonpattern = true;
            }
            else
            {
                pauseonpattern = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CashoutcheckBox2 = CashoutcheckBox2.Checked;

        }

        private void StopWincheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StopWincheckBox2 = StopWincheckBox2.Checked;
            if (StopWincheckBox2.Checked == true)
            {
                stopafterwin = true;
            }
            else
            {
                stopafterwin = false;
            }
        }

        private void StopAutocheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StopAutocheckBox2 = StopAutocheckBox2.Checked;
            if (StopAutocheckBox2.Checked == true)
            {
                
                stopaftermulti = true;
            }
            else
            {
                
                stopaftermulti = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            patternBox.Text = Properties.Settings.Default.pattern;
            BaseBetAmount.Value = Properties.Settings.Default.basebet;
            textBox1.Text = Properties.Settings.Default.apikey;
            CurrencyList.Text = Properties.Settings.Default.currency;
            rankBox.Text = Properties.Settings.Default.startcard;
            suitBox.Text = Properties.Settings.Default.startcardsuit;
            DelayBet.Value = Properties.Settings.Default.betdeley;
            DelayGuess.Value = Properties.Settings.Default.guessdelay;
            StopLimit.Value = Properties.Settings.Default.gamecountstop;
            StopAutocheckBox2.Checked = Properties.Settings.Default.StopAutocheckBox2;
            StopWincheckBox2.Checked = Properties.Settings.Default.StopWincheckBox2;
            CashoutcheckBox2.Checked = Properties.Settings.Default.CashoutcheckBox2;
            checkBox1.Checked = Properties.Settings.Default.checkBox1;

            PauseMulticheckBox.Checked = Properties.Settings.Default.PauseMulticheckBox;
            SeedcheckBox.Checked = Properties.Settings.Default.SeedcheckBox;
            StopAutoValue.Value = Properties.Settings.Default.StopAutoValue;
            AutoCashout.Value = Properties.Settings.Default.AutoCashout;
            PauseMulti.Value = Properties.Settings.Default.PauseMulti;
            IncrementLoss.Value = Properties.Settings.Default.IncrementLoss;
            ResettoBaseWin.Checked = Properties.Settings.Default.ResettoBaseWin;
            ResetBaseStop.Checked = Properties.Settings.Default.ResetBaseStop;
            Seedxbets.Value = Properties.Settings.Default.Seedxbets;
            SeedxLose.Value = Properties.Settings.Default.SeedxLose ;
            SeedxWin.Value = Properties.Settings.Default.SeedxWin;
            comboBox1.Text = Properties.Settings.Default.Mirror;
            SeedBox3.Text = Properties.Settings.Default.clientseed;

            afterlosetreakOf.Value = Properties.Settings.Default.afterlosetreakOf;
            betIncrement.Value = Properties.Settings.Default.betIncrement;
            afterbetsOf.Value = Properties.Settings.Default.afterbetsOf;
            lossesIncrement.Value = Properties.Settings.Default.lossesIncrement;
            afterlossesOf.Value = Properties.Settings.Default.afterlossesOf;
            losesteakIncrement.Value = Properties.Settings.Default.losesteakIncrement;
            resetBasewinstreakOf.Value = Properties.Settings.Default.resetBasewinstreakOf;
            ResetBasewinstreakcheckBox2.Checked = Properties.Settings.Default.ResetBasewinstreakcheckBox2 ;
            resetBasewinsOf.Value = Properties.Settings.Default.resetBasewinsOf;
        }




       
        private void rankBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startcard = rankBox.Text;
            if (System.Text.RegularExpressions.Regex.IsMatch(rankBox.Text, "^[2-9AJQK]*$") == false)
            {
                EditStatus("You may type only number 2-10 and A, J, Q or K as rank");
            }
        }
        char[] suitchar = { 'H', 'S', 'C', 'D' };
        private void suitBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startcardsuit = suitBox.Text;
            if(suitchar.Any(c => suitBox.Text.Contains(c)) == false)
            {
                EditStatus("You may type only H, C, D or S as suit");
            }
        }
        private int IndexCurrency()
        {
            for(var i = 0; i < CurrencyList.Items.Count; i++)
            {
                if (CurrencyList.Items[i].ToString() == CurrencyList.Text)
                {
                    return i;
                }

            }
            return 0;
        }
        private void CurrencyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.currency = CurrencyList.Text;
            if (loggedin)
            {
                
                ResetStats();
                currencyindex = CurrencyList.SelectedIndex;
                balance = balances[CurrencyList.SelectedIndex];
                UpdateStats();
            }
            
        }

        private void StopLimit_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.gamecountstop = StopLimit.Value;
        }

        private void DelayBet_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.betdeley = DelayBet.Value;
        }

        private void DelayGuess_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.guessdelay = DelayGuess.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.apikey = textBox1.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetStats();
        }

        private void PauseMulticheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PauseMulticheckBox = PauseMulticheckBox.Checked;

        }

        private void SeedcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SeedcheckBox = SeedcheckBox.Checked;
        }

        private void StopAutoValue_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StopAutoValue = StopAutoValue.Value;
        }

        private void AutoCashout_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoCashout = AutoCashout.Value;
        }

        private void PauseMulti_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PauseMulti = PauseMulti.Value;
        }

        private void IncrementLoss_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IncrementLoss = IncrementLoss.Value;
        }

        private void ResettoBaseWin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResettoBaseWin = ResettoBaseWin.Checked;
        }

        private void ResetBaseStop_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResetBaseStop = ResetBaseStop.Checked;
        }

        private void Seedxbets_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Seedxbets = Seedxbets.Value;
        }

        private void SeedxLose_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SeedxLose = SeedxLose.Value;
        }

        private void SeedxWin_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SeedxWin = SeedxWin.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mirror = comboBox1.Text;
            mirror = "https://api." + comboBox1.Text + "/graphql";
            AddLog("Site changed to: " + comboBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.clientseed = SeedBox3.Text;
        }

        private void labelProfit_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel2.Text.Contains("Hide"))
            {
                linkLabel2.Text = "Show Stats";
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                mainBalance.Visible = false;
                mainProfit.Visible = false;
                mainWager.Visible = false;
            }
            else
            {
                linkLabel2.Text = "Hide Stats";
                label30.Visible = true;
                label31.Visible = true;
                label32.Visible = true;
                mainBalance.Visible = true;
                mainProfit.Visible = true;
                mainWager.Visible = true;
            }
            
        }

        private void betIncrement_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.betIncrement = betIncrement.Value;
        }

        private void afterbetsOf_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.afterbetsOf = afterbetsOf.Value;
        }

        private void lossesIncrement_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.lossesIncrement = lossesIncrement.Value;
        }

        private void afterlossesOf_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.afterlossesOf = afterlossesOf.Value;
        }

        private void losesteakIncrement_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.losesteakIncrement = losesteakIncrement.Value;
        }

        private void afterlosetreakOf_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.afterlosetreakOf = afterlosetreakOf.Value;
        }
        //wins reset
        private void resetBasewinstreakOf_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.resetBasewinstreakOf = resetBasewinstreakOf.Value;
        }

        private void ResetBasewinstreakcheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResetBasewinstreakcheckBox2 = ResetBasewinstreakcheckBox2.Checked;
        }

        private void resetBasewinsOf_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.resetBasewinsOf = resetBasewinsOf.Value;
        }
    }
}
