using AirtableApiClient;
namespace Flashcard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private CardBox.Languages _currentPrimaryLanguage;
        private CardBox.Difficulties _currentDifficulty;
        private CardBox _box = new CardBox();
        private string DifficultyText
        {
            get
            {
                if(_currentDifficulty == 0)
                {
                    return "basis";
                }
                else
                {
                    return "erweitert";
                }
            }
        }
        private string LanguageText
        {
            get
            {
                if (_currentPrimaryLanguage == 0)
                {
                    return "deu->eng";
                }
                else
                {
                    return "end->deu";
                }
            }
        }

        //on start of Form adding Slotnumbers to combobox
        private void MainForm_Load(object sender, EventArgs e)
        {
            for(int i = 1; i <= _box.SlotCount; i++)
            {
                _cbSlotNumber.Items.Add(i.ToString());
            }

            LoadSaveState();
            FillTranslationList();
            SetRandomWordToTranslate();
        }

        private void LoadSaveState()
        {
            _currentDifficulty = _box.GetCurrentDifficulty();
            _currentPrimaryLanguage = _box.GetPrimaryLanguage();
            _btnSwitchDifficulty.Text = DifficultyText;
            _btnSwitchLanguage.Text = LanguageText;

            _cbSlotNumber.SelectedIndex = _box.GetCurrentSlotIndex();
        }

        //temp choosing a random word to Translate
        private void BtnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            _box.SwitchDifficulty();
            FillTranslationList();
            SetRandomWordToTranslate();
            if (_currentDifficulty == CardBox.Difficulties.Basic)
            {
                _currentDifficulty = CardBox.Difficulties.Advanced;
            }
            else
            {
                _currentDifficulty = CardBox.Difficulties.Basic;
            }

            _btnSwitchDifficulty.Text = DifficultyText;
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
                const string buttonText = "Bestätigen";

                if (_btnSubmit.Text == buttonText)
                {
                    _btnSubmit.Text = "Weiter";
                    _lblValidation.Text = _box.VerifyTranslation(_lbTranslationList.SelectedItem.ToString());
                }
                else
                {
                    _btnSubmit.Text = buttonText;
                    _lblValidation.Text = String.Empty;
                    SetRandomWordToTranslate();
                    FillTranslationList();
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
            _box.SwitchSlot(Int32.Parse(_cbSlotNumber.SelectedItem.ToString()));
            FillTranslationList();
            SetRandomWordToTranslate();
        }

        private void BtnSwitchLanguage_Click(object sender, EventArgs e)
        {
            _box.SwitchLanguage();
            FillTranslationList();
            SetRandomWordToTranslate();
            if (_currentPrimaryLanguage == CardBox.Languages.German)
            {
                _currentPrimaryLanguage = CardBox.Languages.English;
            }
            else
            {
                _currentPrimaryLanguage = CardBox.Languages.German;
            }

            _btnSwitchLanguage.Text = LanguageText;
        }

        private void BtnAddCard_OnClick(object sender, EventArgs e)
        { 
            
            EditCardForm editCard = new EditCardForm();
            editCard.ShowDialog();
            if (editCard.ShouldExecute)
            {
                _box.AddNewCard(editCard.GetGermanWord(), editCard.GetEnglishWord(), editCard.GetDifficulty());
                FillTranslationList();
            }
        }

        private void BtnEndProgram_Click(object sender, EventArgs e)
        {
            _box.UpdateSaveState();
            this.Close();
           
        }

        private void BtnCardList_OnClick(object sender, EventArgs e)
        {
            CardListForm cardList = new CardListForm(_box.GetCardList());
            cardList.ShowDialog();

            FillTranslationList();
            SetRandomWordToTranslate();
        }

        private void BtnReset_OnClick(object sender, EventArgs e)
        {
            _box.ResetAllCardSlots();
            FillTranslationList();
            SetRandomWordToTranslate();
        }

        private void _btnSkip_Click(object sender, EventArgs e)
        {
            SetRandomWordToTranslate();
            FillTranslationList();
        }
    }
}