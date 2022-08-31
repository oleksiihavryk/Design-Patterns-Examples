namespace CreatingPatterns.Factory;
public class Product
{
    public class ProductFactory
    {
        public Product CreateLiquidFood(
            string name,
            decimal priceForOne,
            int count, 
            string measure)
        {
            var p = new Product(
                name,
                priceForOne,
                count,
                measure,
                type: ProductType.Eat,
                isLiquid: true);

            return p;
        }
        public Product CreateLiquidChemicals(
            string name,
            decimal priceForOne,
            int count,
            string measure)
        {
            var p = new Product(
                name,
                priceForOne,
                count,
                measure,
                type: ProductType.Chemicals,
                isLiquid: true);

            return p;
        }
        public Product CreateLiquidOthers(
            string name,
            decimal priceForOne,
            int count,
            string measure)
        {
            var p = new Product(
                name,
                priceForOne,
                count,
                measure,
                type: ProductType.Other,
                isLiquid: true);

            return p;
        }
        public Product CreateNonLiquidFood(
            string name,
            decimal priceForOne,
            int count,
            string measure)
        {
            var p = new Product(
                name,
                priceForOne,
                count,
                measure,
                type: ProductType.Eat,
                isLiquid: false);

            return p;
        }
        public Product CreateNonLiquidChemicals(
            string name,
            decimal priceForOne,
            int count,
            string measure)
        {
            var p = new Product(
                name,
                priceForOne,
                count,
                measure,
                type: ProductType.Chemicals,
                isLiquid: false);

            return p;
        }
        public Product CreateNonLiquidOthers(
            string name,
            decimal priceForOne,
            int count,
            string measure)
        {
            var p = new Product(
                name,
                priceForOne,
                count,
                measure,
                type: ProductType.Other,
                isLiquid: false);

            return p;
        }
    }

    private int _count;
    private decimal _priceForOne;

    public static ProductFactory Factory => new ProductFactory();

    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal PriceForOne
    {
        get => _priceForOne;
        set => _priceForOne = value >= 0 ? value : throw new ArgumentOutOfRangeException(
            nameof(PriceForOne));
    }
    public int Count
    {
        get => _count;
        set => _count = value > 0 ? value : throw new ArgumentOutOfRangeException(
            nameof(Count));
    }
    public string Measure { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice => PriceForOne * Count;
    public ProductType Type { get; set; }
    public bool IsLiquid { get; set; }

    private Product()
        : this(
            id: Guid.NewGuid(),
            name: string.Empty,
            priceForOne: decimal.Zero, 
            count: 0,
            measure: string.Empty,
            createdAt: DateTime.Now.ToUniversalTime(),
            type: ProductType.Unknown,
            isLiquid: false)
    {
    }
    private Product(
        string name, 
        decimal priceForOne, 
        int count, 
        string measure,
        ProductType type,
        bool isLiquid)
        : this (
            id: Guid.NewGuid(), 
            name, 
            priceForOne,
            count,
            measure,
            createdAt: DateTime.Now.ToUniversalTime(),
            type,
            isLiquid)
    {
    }
    private Product(
        Guid id,
        string name,
        decimal priceForOne,
        int count,
        string measure,
        DateTime createdAt,
        ProductType type,
        bool isLiquid)
    {
        Id = id;
        Name = name;
        PriceForOne = priceForOne;
        Count = count;
        Measure = measure;
        CreatedAt = createdAt;
        Type = type;
        IsLiquid = isLiquid;
    }

    public override string ToString()
    {
        return $"{Name}: " + 
               (IsLiquid ? "Liquid" : "Non-liquid") + 
               $" {Type} for {TotalPrice} with {Count}{Measure} " +
               $"and {PriceForOne} for one peace" + 
               "{Created at" + CreatedAt.ToString() + "}";
    }
}