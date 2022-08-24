namespace FlashcardTest
{
    [TestClass]
    public class CardBoxTest2
    {
        private void AddCardToList(string wordToTranslate, string translation, string key, Flashcard.CardBox.Difficulties difficulty, List<Flashcard.Card> cardList)
        {
            cardList.Add(new Flashcard.Card(wordToTranslate, translation, 1, difficulty, key));
        }

        private Flashcard.CardBox InitCardBox()
        {
            int[] saveState = { 0, 0, 0 };
            List<Flashcard.Card> sampleCardList = new List<Flashcard.Card>();
            AddCardToList("Tisch", "table", "rBjSo7Cp3C3TtISnYc", Flashcard.CardBox.Difficulties.Basic, sampleCardList);
            AddCardToList("Sonne", "sun", "dkjUDlm6oa658k3mnC", Flashcard.CardBox.Difficulties.Basic, sampleCardList);
            AddCardToList("Stuhl", "chair", "r0uj2RIS2NUQpgGXO4", Flashcard.CardBox.Difficulties.Basic, sampleCardList);
            AddCardToList("Schrecken", "dread", "1Uxk723tr0FzNucsO1", Flashcard.CardBox.Difficulties.Advanced, sampleCardList);
            AddCardToList("Zorn", "wrath", "F6L8JgL70qpLFu8WlR", Flashcard.CardBox.Difficulties.Advanced, sampleCardList);
            AddCardToList("zögern", "hesitate", "K0B9I6wEASbQX6bcOx", Flashcard.CardBox.Difficulties.Advanced, sampleCardList);
            return new Flashcard.CardBox(saveState, sampleCardList);
        }

        [TestMethod]
        public void TestSwitchDifficutly()
        {
            var sampleBox = InitCardBox();
            Flashcard.CardBox.Difficulties expected = Flashcard.CardBox.Difficulties.Advanced;

            sampleBox.SwitchDifficulty();

            Flashcard.CardBox.Difficulties actual = sampleBox.GetCurrentDifficulty();
            Assert.AreEqual(expected, actual, "SwitchDifficulty failed");
        }
    }
}
