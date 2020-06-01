namespace ConsoleApp.Patterns
{
    public class House
    {
        private int _rooms;
        private int _doors;
        private int _windows;
        private bool _hasGarage;
        private bool _hasSwimmingPool;

        public int Rooms
        {
            get => _rooms;
            set => _rooms = value;
        }

        public int Doors
        {
            get => _doors;
            set => _doors = value;
        }

        public int Windows
        {
            get => _windows;
            set => _windows = value;
        }

        public bool HasGarage
        {
            get => _hasGarage;
            set => _hasGarage = value;
        }

        public bool HasSwimmingPool
        {
            get => _hasSwimmingPool;
            set => _hasSwimmingPool = value;
        }

        // public House(int rooms, int doors, int windows, bool hasGarage, bool hasSwimmingPool = false)
        // {
        //     _rooms = rooms;
        //     _doors = doors;
        //     _windows = windows;
        //     _hasGarage = hasGarage;
        //     _hasSwimmingPool = hasSwimmingPool;
        // }
    }

    public class HouseBuilder : IDoorHouseBuilder, IRoomsHouseBuilder,
        IWindowsHouseBuilder, IFinalHouseBuilder
    {
        House _house = new House();

        private HouseBuilder(){}

        public static IRoomsHouseBuilder GetBuilder()
        {
            return new HouseBuilder();
        }
        
        public IDoorHouseBuilder Rooms(int rooms)
        {
            _house.Rooms = rooms;
            return this;
        }

        public IFinalHouseBuilder CreateBungalow()
        {
            return Rooms(1).Doors(1).Windows(1);
        }

        public IWindowsHouseBuilder Doors(int doors)
        {
            _house.Doors = doors;
            return this;
        }

        public IFinalHouseBuilder Windows(int windows)
        {
            _house.Windows = windows;
            return this;
        }

        public IFinalHouseBuilder HasGarage()
        {
            _house.HasGarage = true;
            return this;
        }

        public IFinalHouseBuilder HasPool()
        {
            _house.HasSwimmingPool = true;
            return this;
        }

        public House Build()
        {
            return _house;
        }
    }

    public interface IRoomsHouseBuilder
    {
        IDoorHouseBuilder Rooms(int rooms);
        IFinalHouseBuilder CreateBungalow();
    }

    public interface IDoorHouseBuilder
    {
        IWindowsHouseBuilder Doors(int doors);
    }

    public interface IWindowsHouseBuilder
    {
        IFinalHouseBuilder Windows(int windows);
    }

    public interface IFinalHouseBuilder
    {
        IFinalHouseBuilder HasGarage();
        IFinalHouseBuilder HasPool();
        House Build();

    }


}