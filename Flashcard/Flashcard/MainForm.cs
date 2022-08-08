namespace Flashcard
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        
        private Slot _slot1 = new Slot();
        private Slot _slot2 = new Slot();
        private Slot _slot3 = new Slot();
        private List<Slot> _slotList = new List<Slot>();
        private string _dataFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "data.txt");
        private CardBox _box;

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetClassVariables();

            _cbSlotNumber.Items.Add(_slot1.SlotID.ToString());
            _cbSlotNumber.Items.Add(_slot2.SlotID.ToString());
            _cbSlotNumber.Items.Add(_slot3.SlotID.ToString());
            _cbSlotNumber.SelectedIndex = 0;

            //reading data from data.txt and putting it into Cards

            
            //printing data to interface
            FillTranslationList();
            _lblWordToTranslate.Text = _box.SelectRandomWordToTranslate();
        }

        private void SetClassVariables()
        {
            _slot1.SlotID = 1;
            _slot1.CardList = new List<Card>();
            _slotList.Add(_slot1);
            _slot2.SlotID = 2;
            _slot2.CardList = new List<Card>();
            _slotList.Add(_slot2);
            _slot3.SlotID = 3;
            _slot3.CardList = new List<Card>();
            _slotList.Add(_slot3);
            _box = new CardBox(_slotList, _dataFilePath);
        }


        private void BtnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            SetRandomWordToTranslate();
        }

        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void FillTranslationList()
        {
            _lbTranslationList.Items.Clear();
            string[] listOfTranslations = _box.ShowPossibleTranslations();
            foreach (string word in listOfTranslations)
            {
                _lbTranslationList.Items.Add(word);
            } 
        }

        //checking wether the selected item in _lbTranslationList equals the correct Translation of _lblWordToTranslate
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            const string buttonText = "Bestštigen";

            if(_btnSubmit.Text == buttonText)
            {
                _btnSubmit.Text = "Weiter";
                _lblValidation.Text = _box.Validate(_lbTranslationList.SelectedItem.ToString());
            }
            else
            {
                _btnSubmit.Text = buttonText;
                _lblValidation.Text = "";
                _lblWordToTranslate.Text = _box.SelectRandomWordToTranslate();
            }
            
            
            FillTranslationList();
        }

        private void SetRandomWordToTranslate()
        {
            _lblWordToTranslate.Text = _box.SelectRandomWordToTranslate();
        }

        private void MainForm_Closing(object sender, EventArgs e)
        {

        }

        private void CbSlotNumberSelectIndexChanged(object sender, EventArgs e)
        {
            _box.switchSlot(Int32.Parse(_cbSlotNumber.SelectedItem.ToString()));
            FillTranslationList();
        }
    }
}