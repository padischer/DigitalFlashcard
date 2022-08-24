

namespace FlashcardTest
{
    [TestClass]
    public class CarBoxTest
    {
        private int[] _saveState = { 0, 0, 0 };
        private List<Flashcard.Card> _sampleCardList;
        private Flashcard.CardBox _sampleBox;

        private void AddCardToList(string wordToTranslate, string translation, string key, Flashcard.CardBox.Difficulties difficulty)
        {
            _sampleCardList.Add(new Flashcard.Card(wordToTranslate, translation, 1, difficulty, key));
        }

        private void InitCardBox()
        {
            _sampleCardList = new List<Flashcard.Card>();
            AddCardToList("Tisch", "table", "rBjSo7Cp3C3TtISnYc", Flashcard.CardBox.Difficulties.Basic);
            AddCardToList("Sonne", "sun", "dkjUDlm6oa658k3mnC", Flashcard.CardBox.Difficulties.Basic);
            AddCardToList("Stuhl", "chair", "r0uj2RIS2NUQpgGXO4", Flashcard.CardBox.Difficulties.Basic);
            AddCardToList("Schrecken", "dread", "1Uxk723tr0FzNucsO1", Flashcard.CardBox.Difficulties.Advanced);
            AddCardToList("Zorn", "wrath", "F6L8JgL70qpLFu8WlR", Flashcard.CardBox.Difficulties.Advanced);
            AddCardToList("zögern", "hesitate", "K0B9I6wEASbQX6bcOx", Flashcard.CardBox.Difficulties.Advanced);
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

        [TestMethod]
        public void TestSwitchSlot()
        {
            InitCardBox();
            int expected = 0;

            _sampleBox.SwitchSlot(0);

            int actual = _sampleBox.GetCurrentSlotIndex();
            Assert.AreEqual(expected, actual, "too small input uncatched");
        }

        [TestMethod]
        public void TestSwitchSlot1()
        {
            InitCardBox();
            int expected = 2;

            _sampleBox.SwitchSlot(3);

            int actual = _sampleBox.GetCurrentSlotIndex();
            Assert.AreEqual(expected, actual, "SwitchSlot failed");
        }

        [TestMethod]
        public void TestVerifyTranslation()
        {
            InitCardBox();
            _sampleBox.SetCurrentCard(_sampleCardList.First());
            bool expected = true;

            bool actual = _sampleBox.VerifyTranslation("table");

            Assert.AreEqual(expected, actual, "Verification failed");
        }

        [TestMethod]
        public void TestVerifyTranslation1()
        {
            InitCardBox();
            _sampleBox.SetCurrentCard(_sampleCardList.First());
            bool expected = false;

            bool actual = _sampleBox.VerifyTranslation("Tisch");

            Assert.AreEqual(expected, actual, "wrongly succeeded");
        }

        [TestMethod]
        public void TestResetAllCardSlots()
        {
            InitCardBox();
            foreach(Flashcard.Card card in _sampleCardList)
            {
                card.SlotID = 2;
            }
            int expected = 6;

            _sampleBox.ResetAllCardSlots();


        }

    }
}
