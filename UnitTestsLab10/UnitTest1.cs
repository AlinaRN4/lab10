using ClassLibrary10lab;
namespace UnitTestsLab10
{
    [TestClass]
    public class MusicalInstrumentTests
    {
        [TestMethod]
        public void ConstructorWithName_SetsName()
        {
            string name = "Guitar";

            MusicalInstrument instrument = new MusicalInstrument(name);

            Assert.AreEqual(name, instrument.Name);
        }

        [TestMethod]
        public void DefaultConstructor_SetsNameToUnknown()
        {
            MusicalInstrument instrument = new MusicalInstrument();

            Assert.AreEqual("Неизвестный", instrument.Name);
        }

        [TestMethod]
        public void ToString_ReturnsName()
        {
            MusicalInstrument instrument = new MusicalInstrument("Violin");

            string result = instrument.ToString();

            Assert.AreEqual(instrument.Name, result);
        }

        //Гитара
        [TestMethod]
        public void ConstructorWithNameAndNumberOfStrings_SetsNameAndNumberOfStrings()
        {
            string name = "Guitar";
            int numberOfStrings = 6;

            Guitar guitar = new Guitar(name, numberOfStrings);

            Assert.AreEqual(name, guitar.Name);
            Assert.AreEqual(numberOfStrings, guitar.NumberOfStrings);
        }

        [TestMethod]
        public void DefaultConstructor_SetsNameToUnknownAndNumberOfStringsToZero()
        {
            Guitar guitar = new Guitar();

            Assert.AreEqual("Неизвестный", guitar.Name);
            Assert.AreEqual(0, guitar.NumberOfStrings);
        }

        [TestMethod]
        public void ToString_ReturnsNameAndNumberOfStrings()
        {
            Guitar guitar = new Guitar("Guitar", 5);

            string result = guitar.ToString();

            Assert.AreEqual(guitar.Name + ", " + guitar.NumberOfStrings, result);
        }

        [TestMethod]
        public void NumberOfStringsOutOfRange_ThrowsException()
        {
            Guitar guitar = new Guitar();

            Assert.ThrowsException<Exception>(() => guitar.NumberOfStrings = 3);
            Assert.ThrowsException<Exception>(() => guitar.NumberOfStrings = 13);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForGuitars()
        {
            Guitar guitar1 = new Guitar("Гитара", 6);
            Guitar guitar2 = new Guitar("Гитара", 6);

            Assert.IsTrue(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void Equals_ReturnsFalseForDifferentGuitars()
        {
            Guitar guitar1 = new Guitar("Гитара", 6);
            Guitar guitar2 = new Guitar("Гитара", 8);

            Assert.IsFalse(guitar1.Equals(guitar2));
        }
        //Электрогитара
        [TestMethod]
        public void ConstructorWithNameNumberOfStringsAndPowerSource_SetsNameNumberOfStringsAndPowerSource()
        {
            string name = "Электрогитара";
            int numberOfStrings = 6;
            string powerSource = "Аккумулятор";

            ElectricGuitar electricGuitar = new ElectricGuitar(name, numberOfStrings, powerSource);

            Assert.AreEqual(name, electricGuitar.Name);
            Assert.AreEqual(numberOfStrings, electricGuitar.NumberOfStrings);
            Assert.AreEqual(powerSource, electricGuitar.PowerSource);
        }

        [TestMethod]
        public void DefaultConstructor_SetsNameToNoNameNumberOfStringsToZeroAndPowerSourceToNoStyle()
        {
            ElectricGuitar electricGuitar = new ElectricGuitar();

            Assert.AreEqual("No name", electricGuitar.Name);
            Assert.AreEqual(0, electricGuitar.NumberOfStrings);
            Assert.AreEqual("No style", electricGuitar.PowerSource);
        }

        [TestMethod]
        public void ToString_ReturnsNameNumberOfStringsAndPowerSource()
        {
            ElectricGuitar electricGuitar = new ElectricGuitar("Электрогитара", 7, "Фиксированный источник питания");

            string result = electricGuitar.ToString();

            Assert.AreEqual(electricGuitar.Name + ", " + electricGuitar.NumberOfStrings + ", " + electricGuitar.PowerSource, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForEqualElectricGuitars()
        {
            ElectricGuitar guitar1 = new ElectricGuitar("Электрогитара", 6, "Батарейки");
            ElectricGuitar guitar2 = new ElectricGuitar("Электрогитара", 6, "Батарейки");

            Assert.IsTrue(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void Equals_ReturnsFalseForDifferentElectricGuitars()
        {
            ElectricGuitar guitar1 = new ElectricGuitar("Электрогитара", 6, "Батарейки");
            ElectricGuitar guitar2 = new ElectricGuitar("Электрогитара", 6, "USB");

            Assert.IsFalse(guitar1.Equals(guitar2));
        }

        //Пианино
        [TestMethod]
        public void ConstructorWithNameKeyboardLayoutAndNumberOfKeys_SetsNameKeyboardLayoutAndNumberOfKeys()
        {
            string name = "Пианино";
            string keyboardLayout = "Октавная";
            int numberOfKeys = 88;

            Piano piano = new Piano(name, keyboardLayout, numberOfKeys);

            Assert.AreEqual(name, piano.Name);
            Assert.AreEqual(keyboardLayout, piano.KeyboardLayout);
            Assert.AreEqual(numberOfKeys, piano.NumberOfKeys);
        }

        [TestMethod]
        public void DefaultConstructor_SetsNameToNoNameKeyboardLayoutToNoStyleAndNumberOfKeysToZero()
        {
            Piano piano = new Piano();

            Assert.AreEqual("No name", piano.Name);
            Assert.AreEqual("NoStyle", piano.KeyboardLayout);
            Assert.AreEqual(0, piano.NumberOfKeys);
        }

        [TestMethod]
        public void NumberOfKeys_SetInvalidNumberOfKeys_ThrowsException()
        {
            var piano = new Piano();

            Assert.ThrowsException<Exception>(() => piano.NumberOfKeys = 90);
        }

        [TestMethod]
        public void Show_DisplayInstrumentInfo_ReturnsCorrectString()
        {
            var piano = new Piano();
            piano.Name = "Piano";
            piano.KeyboardLayout = "октавная";
            piano.NumberOfKeys = 88;

            var expected = "Музыкальный инструмент: Piano, Раскладка клавиш: октавная, Кол-во клавиш: 88";
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                piano.Show();
                Assert.AreEqual(expected, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void ToString_ReturnsNameKeyboardLayoutAndNumberOfKeys()
        {
            Piano piano = new Piano("Пианино", "Шкальная", 76);

            string result = piano.ToString();

            Assert.AreEqual(piano.Name + ", " + piano.KeyboardLayout + ", " + piano.NumberOfKeys, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForEqualPianos()
        {
            Piano piano1 = new Piano("Пианино", "Шкальная", 76);
            Piano piano2 = new Piano("Пианино", "Шкальная", 76);

            Assert.IsTrue(piano1.Equals(piano2));
        }

        [TestMethod]
        public void Equals_ReturnsFalseForDifferentPianos()
        {
            Piano piano1 = new Piano("Пианино", "Шкальная", 76);
            Piano piano2 = new Piano("Пианино", "Октавная", 76);

            Assert.IsFalse(piano1.Equals(piano2));
        }

        //Студент
        [TestMethod]
        public void Name_SetValidName_NameIsSet()
        {
            var student = new Student();

            student.Name = "John";

            Assert.AreEqual("John", student.Name);
        }

        [TestMethod]
        public void Name_SetNull_ThrowsException()
        {
            var student = new Student();

            Assert.ThrowsException<ArgumentNullException>(() => student.Name = null);
        }

        [TestMethod]
        public void Age_SetValidAge_AgeIsSet()
        {
            var student = new Student();

            student.Age = 20;

            Assert.AreEqual(20, student.Age);
        }

        [TestMethod]
        public void Age_SetInvalidAge_ThrowsException()
        {
            var student = new Student();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => student.Age = 150);
        }

        [TestMethod]
        public void GPA_SetValidGPA_GPAIsSet()
        {
            var student = new Student();

            student.GPA = 3.5;

            Assert.AreEqual(3.5, student.GPA);
        }

        [TestMethod]
        public void GPA_SetInvalidGPA_ThrowsException()
        {
            var student = new Student();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => student.GPA = 4.5);
        }
    }
}