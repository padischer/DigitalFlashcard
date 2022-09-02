namespace FlashcardTest
{
    [TestClass]
    public class CardTest
    {
        private Flashcard.Card CreateSampleCard()
        {
            return new Flashcard.Card("Tisch", "table", Flashcard.CardBox.Slots.FirstSlot, Flashcard.CardBox.Difficulties.Basic, "dkjUDlm6oa658k3mnC");
        }

        [TestMethod]
        public void TestVerifyTranslationWithWrongInput()
        {
            var sampleCard = CreateSampleCard();

            bool actual = sampleCard.VerifyTranslation("table");

            Assert.AreEqual(true, actual, "didn't verify correct input");
        }

        [TestMethod]
        public void TestVerifyTranslationWithCorrectInput()
        {
            var sampleCard = CreateSampleCard();

            bool actual = sampleCard.VerifyTranslation("Tisch");

            Assert.AreEqual(false, actual, "didn't verify correct input");
        }

        [TestMethod]
        public void TestGetGermanWord()
        {
            var sampleCard = CreateSampleCard();

            Assert.AreEqual("Tisch", sampleCard.GetGermanWord());
        }

        [TestMethod]
        public void TestGetGermanWordWithSwitchedLanguage()
        {
            var sampleCard = CreateSampleCard();

            sampleCard.SwitchLanguage();

            Assert.AreEqual("Tisch", sampleCard.GetGermanWord());
        }

        [TestMethod]
        public void TestGetEnglishWord()
        {
            var sampleCard = CreateSampleCard();

            Assert.AreEqual("table", sampleCard.GetEnglishWord());
        }

        [TestMethod]
        public void TestGetEnglishWordWithSwitchedLanguage()
        {
            var sampleCard = CreateSampleCard();

            sampleCard.SwitchLanguage();

            Assert.AreEqual("table", sampleCard.GetEnglishWord());
        }

        [TestMethod]
        public void TestSwitchLanguage()
        {
            var sampleCard = CreateSampleCard();

            sampleCard.SwitchLanguage();

            Assert.AreEqual(Flashcard.CardBox.Languages.English, sampleCard.PrimaryLanguage, "did not switch language correctly");
        }
    }
}