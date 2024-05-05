using System.ComponentModel.Design;
using UnityEngine;

public static class MVCFactory
{
    #region Create: Model

    public static TModel CreateModel<TModel, TData>(TData data)
    where TModel : Model<TData>
    where TData : ModelData
    {
        var model = System.Activator.CreateInstance(typeof(TModel), data) as TModel;
        return model;
    }

    #endregion

    #region Create: View
    public static TView CreateView<TView>(string path) where TView : MonoBehaviour
    {
        var view = InstantiateGameObject<TView>(path);
        return view;
    }

    public static TView CreateView<TView>(string path, Transform parent)
        where TView : MonoBehaviour
    {
        var view = InstantiateGameObject<TView>(path, parent);
        return view;
    }
    private static TView InstantiateGameObject<TView>(string path) where TView : MonoBehaviour
    {
        var prefab = Resources.Load<TView>(path) as MonoBehaviour;
        var gameObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        return gameObject.GetComponent<TView>();
    }
    public static TView InstantiateGameObject<TView>(string path, Transform parent) where TView : MonoBehaviour
    {
        var prefab = Resources.Load<TView>(path) as MonoBehaviour;
        var gameObject = GameObject.Instantiate(prefab, parent);
        return gameObject.GetComponent<TView>();
    }
    #endregion

    #region Create: Controller

    public static TController CreateController<TController, TModel, TModelData, TView>(TModel model, TView view)
        where TController : Controller<TModel, TModelData, TView>, new()
        where TModel : Model<TModelData>
        where TModelData : ModelData
        where TView : View<TModel, TModelData>
    {
        var controller = new TController();
        controller.Init(model, view);
        return controller;
    }
    #endregion

}