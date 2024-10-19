namespace Ass4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    
        interface IBroadbandPlan
        {
            int GetBroadbandPlanAmount();
        }
        class Black : IBroadbandPlan
        {
            private readonly bool _isSUbscriptionValid;
            private readonly int _discountPercentage;
            private const int PlanAmount = 3000;

            public Black(bool isSUbscriptionValid, int discountPercentage)
            {
                if (discountPercentage < 0 || discountPercentage > 50)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _isSUbscriptionValid = isSUbscriptionValid;
                    _discountPercentage = discountPercentage;
                }
            }

            public int GetBroadbandPlanAmount()
            {
                if (_isSUbscriptionValid == true)
                {
                    return PlanAmount - (PlanAmount * _discountPercentage / 100);
                }
                else
                {
                    return PlanAmount;
                }
            }
        }
        class Gold : IBroadbandPlan
        {
            private readonly bool _isSUbscriptionValid;
            private readonly int _discountPercentage;
            private const int PlanAmount = 1500;

            public Gold(bool isSUbscriptionValid, int discountPercentage)
            {
                if (discountPercentage < 0 || discountPercentage > 30)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _isSUbscriptionValid = isSUbscriptionValid;
                    _discountPercentage = discountPercentage;
                }
            }

            public int GetBroadbandPlanAmount()
            {
                if (_isSUbscriptionValid == true)
                {
                    return PlanAmount - (PlanAmount * _discountPercentage / 100);
                }
                else
                {
                    return PlanAmount;
                }
            }
        }

        class SubscribePlan
        {
            private readonly IList<IBroadbandPlan> _broadbandPlans;

            public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
            {
                if (broadbandPlans == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _broadbandPlans = broadbandPlans;
                }
            }
            public IList<Tuple<string, int>> GetSubscriptionPlan()
            {
                if (_broadbandPlans == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    IList<Tuple<string, int>> L = new List<Tuple<string, int>>();
                    foreach (var item in _broadbandPlans)
                    {
                        if (item is Black)
                        {
                            L.Add(new Tuple<string, int>("Black", item.GetBroadbandPlanAmount()));
                        }
                        else
                        {
                            L.Add(Tuple.Create("Gold", item.GetBroadbandPlanAmount()));
                        }
                    }
                    return L;
                }
            }
        }

        internal class M1fourth
        {
            public static void Main(string[] args)
            {
                var plans = new List<IBroadbandPlan>() {
            new Black(true,50),
            new Black(false,10),
            new Gold(true,30),
            new Black(true,20),
            new Gold(false,20)
            };
                var subscriptionPlans = new SubscribePlan(plans);
                var result = subscriptionPlans.GetSubscriptionPlan();
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Item1},{item.Item2}");
                }
            }
        }
    }
