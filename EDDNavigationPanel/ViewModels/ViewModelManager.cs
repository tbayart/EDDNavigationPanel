using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace EDDNavigationPanel.ViewModels
{
    internal static class ViewModelManager
    {
        private static Action<object> _viewModelSetter;
        private static readonly MemoryCache _caching;
        private static readonly CacheItemPolicy _cacheItemPolicy;

        static ViewModelManager()
        {
            _caching = new MemoryCache("ViewModelManager");
            _cacheItemPolicy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(15) };
        }

        public static void RegisterViewModelSetter(Action<object> viewModelSetter)
        {
            _viewModelSetter = viewModelSetter;
        }

        public static T SwitchTo<T>()
            where T : INotifyPropertyChanged
        {
            var key = nameof(T);
            if (_caching.Get(key) is not T instance)
            {
                instance = Activator.CreateInstance<T>();
                _caching.Set(key, instance, _cacheItemPolicy);
            }
            _viewModelSetter?.Invoke(instance);
            return instance;
        }
    }
}
