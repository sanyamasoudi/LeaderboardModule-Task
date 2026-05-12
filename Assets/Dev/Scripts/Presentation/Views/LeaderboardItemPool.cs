using UnityEngine;
using UnityEngine.Pool;

namespace Dev.Scripts.Presentation.Views
{
    public class LeaderboardItemPool : MonoBehaviour
    {
        [SerializeField] private LeaderboardItemView itemPrefab;
        [SerializeField] private bool collectionCheck;
        [SerializeField] private int maxSize;
        [SerializeField] private int capacity;
        
        private IObjectPool<LeaderboardItemView> _pool;
        public IObjectPool<LeaderboardItemView> Pool => _pool;

        private void Awake()
        {
            _pool = new ObjectPool<LeaderboardItemView>(OnCreateItem, OnGetFromPool,
                OnReturnToPool, OnDestroyItem, collectionCheck, capacity, maxSize);
        }

        private LeaderboardItemView OnCreateItem()
        {
            var item = Instantiate(itemPrefab, transform);
            item.gameObject.SetActive(false);
            return item;
        }

        private void OnGetFromPool(LeaderboardItemView item)
        {
            item.gameObject.SetActive(true);
        }

        private void OnReturnToPool(LeaderboardItemView item)
        {
            item.gameObject.SetActive(false);
        }

        private void OnDestroyItem(LeaderboardItemView item)
        {
            Destroy(item.gameObject);
        }
    }
}