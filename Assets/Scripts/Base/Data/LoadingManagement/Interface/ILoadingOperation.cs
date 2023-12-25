using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public interface ILoadingOperation
{
    string descriiption { get; set; }
    UniTask ExecuteOperation();
}
