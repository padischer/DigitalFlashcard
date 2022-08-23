namespace FlashcardTest
{
    [TestClass]
    public class CardTest
    {
        private string _wordToTranslate = "Tisch";
        private string _translation = "table";
        private int _slotNumber = 1;
        private Flashcard.CardBox.Difficulties _difficulty = Flashcard.CardBox.Difficulties.Basic;
        private string _iD = "ca3gFnhG74id";

        [TestMethod]
        public void TestVerifyTranslation()
        {
            Flashcard.Card card = new Flashcard.Card(_wordToTranslate, _translation, _slotNumber, _difficulty, _iD);
            string selectedTranslation = "table";
            bool expected = true;

            bool actual = card.VerifyTranslation(selectedTranslation);

            Assert.AreEqual(expected, actual, "didn't verify correct input");
        }
    }
}