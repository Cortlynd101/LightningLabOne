namespace FBAPI.ModelLib;

public interface IDataStore
{
    Task<IEnumerable<IDataObject>> GetAllDataObjects(DataObjectType type);
    Task<IDataObject> GetData(int id, DataObjectType type);
    Task<IDataObject> AddData(IDataObject dataObject);
    Task<IDataObject> UpdateData(IDataObject dataObject);
    Task DeleteDataObj(int id, DataObjectType type);
    Task<IEnumerable<IDataObject>> GetUserRolesAsync(string id);
}
