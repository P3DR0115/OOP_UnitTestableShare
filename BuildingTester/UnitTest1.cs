using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_UnitTestableShare;

namespace BuildingTester
{
    [TestClass]
    public class BuildingTester
    {
        Skyscraper SearsTower;
        Skyscraper WillisTower;
        Elevator shadyElevator;
        AirConditioner ac;

        [TestMethod]
        public void TestSkyscraper()
        {
            // Arrange
            SearsTower = new Skyscraper("TestSears", 110);
            WillisTower = new Skyscraper("TestWillis", 30);

            // Act
            string searsName = SearsTower.Name;
            int searsMax = SearsTower.NumberOfFloors;
            string searsAbout = SearsTower.About();

            string willisAbout = WillisTower.About();

            bool elevDoorfirst = SearsTower.elevator.doorsClosed;
            string elevAbout = SearsTower.elevatorAbout();

            string elevOpenMessage = SearsTower.elevator.closeDoors();
            bool elevDoorSecond = SearsTower.elevator.doorsClosed;

            SearsTower.elevator.closeDoors();
            bool elevDoorThird = SearsTower.elevator.doorsClosed;
            string elevCloseMessage = SearsTower.elevator.About();

            string elevatorUp = SearsTower.UseElevator(50);
            bool doorShouldOpen = SearsTower.elevator.doorsClosed;
            SearsTower.elevator.closeDoors();

            string elevatorDown = SearsTower.elevator.ChangeFloor(40);

            string elevatorDoorsOpen = SearsTower.elevator.ChangeFloor(1000);
            SearsTower.elevator.closeDoors();
            string elevatorMax = SearsTower.elevator.ChangeFloor(1000);

            string closedDoors = SearsTower.elevatorDoors();


            // Assert
            Assert.AreEqual("This " + SearsTower.ToString() + " is named " + searsName + ", has " + searsMax + " number of floors",
                            searsAbout);

            //Skyscrapers have at least 41 floors
            Assert.AreEqual("This " + WillisTower.ToString() + " is named " + "TestWillis" + ", has " + 41 + " number of floors",
                            willisAbout);

            Assert.AreEqual(false, elevDoorfirst);

            Assert.AreEqual("This elevator's doors are open, this elevator's range is 0 to " + "110",
                elevAbout);

            Assert.AreEqual("Doors Closed!", elevOpenMessage);
            Assert.AreEqual(true, elevDoorSecond);

            Assert.AreEqual(true, elevDoorThird);
            Assert.AreEqual("This elevator's doors are closed, this elevator's range is 0 to " + "110", elevCloseMessage);

            Assert.AreEqual("Destination reached, Current Floor: " + 50, elevatorUp);
            Assert.AreEqual(false, doorShouldOpen);

            Assert.AreEqual("Destination reached, Current Floor: " + 40, elevatorDown);

            Assert.AreEqual("Elevator cannot move. Doors must be closed first.", elevatorDoorsOpen);
            Assert.AreEqual("Error: Elevator cannot reach that floor. Elevator range is 0 to " + SearsTower.elevator.maxFloor, elevatorMax);

            Assert.AreEqual("Doors Closed!", closedDoors);


        }
        
        [TestMethod]
        public void TestElevatorCtor()
        {
            shadyElevator = new Elevator(110);

            bool doorStatus = shadyElevator.doorsClosed;
            int curFloor = shadyElevator.currentFloor;
            int penthouse = shadyElevator.maxFloor;

            Assert.AreEqual(false, doorStatus);
            Assert.AreEqual(0, curFloor);
            Assert.AreEqual(110, penthouse);
        }

        [TestMethod]
        public void ACTester()
        {
            // Arrange
            ac = new AirConditioner();

            // Act
            bool acOnInit = ac.TurnedOn;
            float tempInit = ac.Temperature;
            string acInitString = ac.About();
            
            string acToggleOn = ac.ToggleOn();
            string acOnAbout = ac.About();
            string acToggleOff = ac.ToggleOn();
            ac.ToggleOn();

            string raiseTemp = ac.changeTemp(79f);
            string maxTemp = ac.changeTemp(81f);
            string minTemp = ac.changeTemp(59f);
            ac.ToggleOn();
            string failChangeTemp = ac.changeTemp(75f);

            // Assert
            Assert.AreEqual(false, acOnInit);
            Assert.AreEqual(78f, tempInit);
            Assert.AreEqual(ac.ToString() + " is currently off.", acInitString);

            Assert.AreEqual(ac.ToString() + " has been turned on!", acToggleOn);
            Assert.AreEqual(ac.ToString() + " is currently on, maintaining a temperature of " + 78 + " degrees.", acOnAbout);
            Assert.AreEqual(ac.ToString() + " has been turned off!", acToggleOff);

            Assert.AreEqual("Temperature changed to " + ac.Temperature + " degrees.", raiseTemp);
            Assert.AreEqual("Temperature changed to maximum: " + 80 + " degrees.", maxTemp);
            Assert.AreEqual("Temperature changed to mininum: " + 60 + " degrees.", minTemp);
            Assert.AreEqual(ac.ToString() + " is currently off. Cannot Change Temperature.", failChangeTemp);

        }
    }
    

}
