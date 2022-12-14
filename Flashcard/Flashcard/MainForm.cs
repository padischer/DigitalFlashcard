using AirtableApiClient;
using static Flashcard.CardBox;

namespace Flashcard
{
    public partial class MainForm : Form
    {
        private CardBox _box;
        private AccessData _dataManager = new AccessData();
        public MainForm()
        {
            Tuple<CardBox.Slots, CardBox.Languages, CardBox.Difficulties> saveState = _dataManager.GetSaveState();
            _box = new CardBox(saveState.Item1, saveState.Item2, saveState.Item3, _dataManager.GetAllCards());
            InitializeComponent();
        }
        

        //on start of Form adding Slotnumbers to combobox
        private void MainForm_Load(object sender, EventArgs e)
        {  
            for (int i = 1; i <= _box.SlotCount; i++)
            {
                _cbSlotNumber.Items.Add(i.ToString());
            }

            LoadSaveState();
            RefreshListAndWordToTranslate();
        }


        private void LoadSaveState()
        {
            _btnSwitchDifficulty.Text = _box.GetCurrentDifficultyText();
            _btnSwitchLanguage.Text = _box.GetCurrentPrimaryLanguageText();

            _cbSlotNumber.SelectedIndex = Convert.ToInt32(_box.GetCurrentSlot());
        }

        //temp choosing a random word to Translate
        private void BtnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            _box.SwitchDifficulty();
            RefreshListAndWordToTranslate();
            _btnSwitchDifficulty.Text = _box.GetCurrentDifficultyText();
        }

        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void FillTranslationList()
        {
            _lbTranslationList.Items.Clear();
            string[] listOfTranslations = _box.GetPossibleTranslations();
            foreach (string word in listOfTranslations)
            {
                _lbTranslationList.Items.Add(word);
            } 
        }

        //checking wether the selected item in _lbTranslationList equals the correct Translation of _lblWordToTranslate
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (_lbTranslationList.SelectedItems.Count == 1)
            {
                const string buttonText = "Best?tigen";

                if (_btnSubmit.Text == buttonText)
                {
                    if (_box.VerifyTranslation(_lbTranslationList.SelectedItem.ToString()))
                    {
                        _lblValidation.Text = "Korrekt";
                    }
                    else
                    {
                        _lblValidation.Text = "Falsch! " + _box.CurrentCard.Translation + " w?re richtig gewesen";
                    }
                    _btnSubmit.Text = "Weiter";
                }
                else
                {
                    _dataManager.UpdateCardSlot(_box.GetCurrentSlot(), _box.CurrentCard.ID); ;
                    _btnSubmit.Text = buttonText;
                    _lblValidation.Text = String.Empty;
                    RefreshListAndWordToTranslate();
                }
            }
        }

        //choosing a random word to Translate
        private void SetRandomWordToTranslate()
        {
            var randomCard = _box.SelectRandomCard();
            _lblWordToTranslate.Text = randomCard != null ? randomCard.WordToTranslate : String.Empty; 
        }

        //if Slotnumber is changed adjust Translationlist and WortToTranslate to the new Slot
        private void CbSlotNumberSelectIndexChanged(object sender, EventArgs e)
        {
            CardBox.Slots newSlot;
            Enum.TryParse(_cbSlotNumber.SelectedItem.ToString(), out newSlot);
            _box.SwitchSlot(newSlot-1);
            RefreshListAndWordToTranslate();
        }

        private void BtnSwitchLanguage_Click(object sender, EventArgs e)
        {
            _box.SwitchLanguage();
            RefreshListAndWordToTranslate();
            _btnSwitchLanguage.Text = _box.GetCurrentPrimaryLanguageText();
        }

        private void BtnAddCard_OnClick(object sender, EventArgs e)
        { 
            
            EditCardForm editCard = new EditCardForm();
            editCard.ShowDialog();
            if (editCard.ShouldExecute)
            {
                _dataManager.CreateCard(editCard.GetGermanWord(), editCard.GetEnglishWord(), editCard.GetDifficulty());
                _box.AddNewCard(editCard.GetGermanWord(), editCard.GetEnglishWord(), editCard.GetDifficulty());
                FillTranslationList();
            }
        }

        private void BtnEndProgram_Click(object sender, EventArgs e)
        {
            Tuple<CardBox.Slots, CardBox.Languages, CardBox.Difficulties> saveState = _box.GetSaveState();
            _dataManager.UpdateSaveState(saveState.Item1, saveState.Item2, saveState.Item3);
            this.Close();
           
        }

        private void BtnCardList_OnClick(object sender, EventArgs e)
        {
            CardListForm cardList = new CardListForm(_box.GetCardList());
            cardList.ShowDialog();

            RefreshListAndWordToTranslate();
        }

        private void BtnReset_OnClick(object sender, EventArgs e)
        {
            _dataManager.ResetAllCardSlots(_box.GetCardList());
            _box.ResetAllCardSlots();
            RefreshListAndWordToTranslate();
        }

        private void RefreshListAndWordToTranslate()
        {
            SetRandomWordToTranslate();
            FillTranslationList();
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            RefreshListAndWordToTranslate();
        }
    }
}