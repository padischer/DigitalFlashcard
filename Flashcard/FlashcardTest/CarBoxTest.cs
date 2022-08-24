

namespace FlashcardTest
{
    [TestClass]
    public class CarBoxTest
    {
        private int[] _saveState = { 0, 0, 0 };
        private List<Flashcard.Card> _sampleCardList;
        private Flashcard.CardBox _sampleBox;

        private void AddCardToList(string wordToTranslate, string translation, string key, Flashcard.CardBox.Difficulties difficulty, List<Flashcard.Card> cardList)
        {
            cardList.Add(new Flashcard.Card(wordToTranslate, translation, 1, difficulty, key));
        }

        private void InitCardBox()
        {
            _sampleCardList = new List<Flashcard.Card>();
            AddCardToList("Tisch", "table", "rBjSo7Cp3C3TtISnYc", Flashcard.CardBox.Difficulties.Basic, _sampleCardList);
            AddCardToList("Sonne", "sun", "dkjUDlm6oa658k3mnC", Flashcard.CardBox.Difficulties.Basic, _sampleCardList);
            AddCardToList("Stuhl", "chair", "r0uj2RIS2NUQpgGXO4", Flashcard.CardBox.Difficulties.Basic, _sampleCardList);
            AddCardToList("Schrecken", "dread", "1Uxk723tr0FzNucsO1", Flashcard.CardBox.Difficulties.Advanced, _sampleCardList);
            AddCardToList("Zorn", "wrath", "F6L8JgL70qpLFu8WlR", Flashcard.CardBox.Difficulties.Advanced, _sampleCardList);
            AddCardToList("zögern", "hesitate", "K0B9I6wEASbQX6bcOx", Flashcard.CardBox.Difficulties.Advanced, _sampleCardList);
            _sampleBox = new Flashcard.CardBox(_saveState, _sampleCardList);
        }

        [TestMethod]
        public void TestSwitchDifficutly()
        {
            InitCardBox();
            Flashcard.CardBox.Difficulties expected = Flashcard.CardBox.Difficulties.Advanced;

            _sampleBox.SwitchDifficulty();

            Flashcard.CardBox.Difficulties actual = _sampleBox.GetCurrentDifficulty();
            Assert.AreEqual(expected, actual, "SwitchDifficulty failed");
        }
    }
}
