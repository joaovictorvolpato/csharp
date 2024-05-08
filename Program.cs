// See https://aka.ms/new-console-template for more information

public class AssetsPageFilters
{
    public string? MeasuringCode { get; set; }
    public string? ConsumerUnit { get; set; }
    public string? AssetName { get; set; }
    public int? AgentId { get; set; }
    public bool? AgentProfileIsActive { get; set; }
    public bool? IsFictional { get; set; } = null;
    public int Page { get; set; } = 1;
    public int ItensPerPage { get; set; } = 50;
    public string? AssetTypes { get; set; }
    public string? AssetRelationTypes { get; set; }
    
    public string? AssetHiringTypes { get; set; }
    public AssetsPageOrderingColumns OrderingColumn { get; set; } = AssetsPageOrderingColumns.AssetName;
    public OrderingMethod OrderingMethod { get; set; } = OrderingMethod.Asc;
}

public enum AssetsPageOrderingColumns
{
    AssetInternalCode, AssetName, AgentName, RelationType, Type
}

public enum OrderingMethod { Asc, Desc }
public class FilterTester
{
    //private readonly AssetRepository _assetRepository;

    public FilterTester()
    {
        // Instantiate your AssetRepository or inject it through dependency injection
        //_assetRepository = new AssetRepository(); // Example: replace with your actual repository instance
    }

    public async Task TestAllFilterCombinationsAsync()
    {
        // Define all possible values for each filter parameter as lists
        var possibleMeasuringCodes = new List<string> { null, "ABC", "XYZ" };
        var possibleAgentIds = new List<int> { 1, 2, 3 };
        var possibleAgentProfileIsActive = new List<bool> { true, false };
        var possibleAssetHiringTypes = new List<string> { null, "Reduz", "Full-time" };
        var possibleAssetRelationTypes = new List<string> { null, "Cliente", "Supplier" };
        var possibleAssetTypes = new List<string> { null, "Comercializador", "Producer" };
        var possibleConsumerUnits = new List<string> { null, "UnitA", "UnitB" };
        var possibleItemsPerPage = new List<int> { 10, 20, 30 };
        var possibleIsFictionalValues = new List<bool> { true, false };
        var possibleOrderingColumns = new List<AssetsPageOrderingColumns> { AssetsPageOrderingColumns.AssetInternalCode, AssetsPageOrderingColumns.AssetInternalCode };
        var possibleOrderingMethods = new List<OrderingMethod> { OrderingMethod.Asc, OrderingMethod.Desc };

        // Create a list to store all filter combinations
        var allFilters = new List<AssetsPageFilters>();

        // Iterate over all possible combinations of filter values using nested loops
        foreach (var measuringCode in possibleMeasuringCodes)
        {
            foreach (var agentId in possibleAgentIds)
            {
                foreach (var isActive in possibleAgentProfileIsActive)
                {
                    foreach (var hiringType in possibleAssetHiringTypes)
                    {
                        foreach (var relationType in possibleAssetRelationTypes)
                        {
                            foreach (var assetType in possibleAssetTypes)
                            {
                                foreach (var consumerUnit in possibleConsumerUnits)
                                {
                                    foreach (var itemsPerPage in possibleItemsPerPage)
                                    {
                                        foreach (var isFictional in possibleIsFictionalValues)
                                        {
                                            foreach (var orderingColumn in possibleOrderingColumns)
                                            {
                                                foreach (var orderingMethod in possibleOrderingMethods)
                                                {
                                                    // Create a new filter with the current combination of values
                                                    var filter = new AssetsPageFilters
                                                    {
                                                        MeasuringCode = measuringCode,
                                                        AgentId = agentId,
                                                        AgentProfileIsActive = isActive,
                                                        AssetHiringTypes = hiringType,
                                                        AssetRelationTypes = relationType,
                                                        AssetTypes = assetType,
                                                        ConsumerUnit = consumerUnit,
                                                        ItensPerPage = itemsPerPage,
                                                        IsFictional = isFictional,
                                                        OrderingColumn = orderingColumn,
                                                        OrderingMethod = orderingMethod
                                                    };

                                                    // Add the filter to the list of all filters
                                                    allFilters.Add(filter);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Test each filter combination asynchronously
        foreach (var filter in allFilters)
        {
            try
            {
                // Make an asynchronous call to fetch assets using the current filter
                //var response = await _assetRepository.GetAssetsMatchingFilter(1342, filter, false);

                // Process the response or log success
                Console.WriteLine($"Filter Test Succeeded: {filter}");
                // Handle or log the assets retrieved in 'response' as needed
            }
            catch (Exception ex)
            {
                // Handle and log any exceptions that occur during testing
                Console.WriteLine($"Filter Test Failed: {filter}. Error: {ex.Message}");
            }
        }
    }
}

// Usage example:
public class Program
{
    public static async Task Main(string[] args)
    {
        var filterTester = new FilterTester();
        await filterTester.TestAllFilterCombinationsAsync();
    }
}