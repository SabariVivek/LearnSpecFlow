using TechTalk.SpecFlow;

namespace LearnSpecFlow.Hooks
{
    [Binding]
    public sealed class HooksOrder
    {
        [BeforeStep(Order = 10)]
        [Scope(Tag = "Smoke")]
        public void BeforeStep_Smoke()
        {
            Console.WriteLine("<<<<< In Before Step - Smoke >>>>>");
        }

        [BeforeStep(Order = 20)]
        [Scope(Tag = "Regression")]
        public void BeforeStep_Regression()
        {
            Console.WriteLine("<<<<< In Before Step - Regression >>>>>");
        }

        [BeforeStep(Order = 30)]
        [Scope(Tag = "Sanity")]
        public void BeforeStep_Sanity()
        {
            Console.WriteLine("<<<<< In Before Step - Sanity >>>>>");
        }

        [AfterStep(Order = 10)]
        [Scope(Tag = "Smoke")]
        public void AfterStep_Smoke()
        {
            Console.WriteLine("<<<<< In After Step - Smoke >>>>>");
        }

        [AfterStep(Order = 20)]
        [Scope(Tag = "Regression")]
        public void AfterStep_Regression()
        {
            Console.WriteLine("<<<<< In After Step - Regression >>>>>");
        }

        [AfterStep(Order = 30)]
        [Scope(Tag = "Sanity")]
        public void AfterStep_Sanity()
        {
            Console.WriteLine("<<<<< In After Step - Sanity >>>>>");
        }
    }
}