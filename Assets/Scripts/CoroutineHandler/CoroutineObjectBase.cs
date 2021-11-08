using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoroutineHandler
{
    public abstract class CoroutineObjectBase
    {
        public MonoBehaviour Owner { get; private set; }
        public Coroutine Coroutine { get; protected set; }
        public bool IsProcessing => Coroutine != null;

        public virtual event Action OnFinished;
        public virtual event Action OnStoped;

        public CoroutineObjectBase(MonoBehaviour owner)
        {
            this.Owner = owner;
        }
        protected virtual void Reset()
        {
            OnFinished = null;
            OnStoped = null;
        }
        public virtual void Stop()
        {
            if (IsProcessing)
            {
                Owner.StopCoroutine(Coroutine);

                Coroutine = null;

                OnStoped?.Invoke();
            }
        }
    }
}
