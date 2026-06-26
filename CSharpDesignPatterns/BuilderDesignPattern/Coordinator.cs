namespace BuilderDesignPattern
{
    public class Coordinator
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        private Coordinator(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return X + " " + Y + " " + Z;
        }

        public class CoordinatorBuilder
        {
            private int x, y, z;
            public CoordinatorBuilder MetX(int x)
            {
                this.x = x;
                return this;
            }
            public CoordinatorBuilder MetY(int y)
            {
                this.y = y;
                return this;
            }
            public CoordinatorBuilder MetZ(int z)
            {
                this.z = z;
                return this;
            }
            public Coordinator MaakCoordinator()
            {
                return new Coordinator(x, y, z);
            }
        }
    }
}
