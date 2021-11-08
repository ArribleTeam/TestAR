using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoroutineHandler
{
    public class CoroutineObject : CoroutineObjectBase, ICoroutine
    {
        public Func<IEnumerator> Routine { get; protected set; }

        public override event Action OnFinished;

        public CoroutineObject(MonoBehaviour owner, Func<IEnumerator> routine) : base(owner)
        {
            Routine = routine;
        }

        private IEnumerator Process()
        {
            yield return Routine.Invoke();

            Coroutine = null;

            OnFinished?.Invoke();
        }

        public void Start()
        {
            Stop();

            base.Reset();

            Coroutine = Owner.StartCoroutine(Process());
        }
    }
    public class CoroutineObject<T> : CoroutineObjectBase, ICoroutine<T>
    {
        public Func<T, IEnumerator> Routine { get; private set; }

        public override event Action OnFinished;

        public CoroutineObject(MonoBehaviour owner, Func<T, IEnumerator> routine) : base(owner)
        {
            Routine = routine;
        }

        private IEnumerator Process(T arg)
        {
            yield return Routine.Invoke(arg);

            Coroutine = null;

            OnFinished?.Invoke();
        }

        public void Start(T arg)
        {
            base.Reset();
            Stop();

            Coroutine = Owner.StartCoroutine(Process(arg));
        }
    }
    public class CoroutineObject<T, R> : CoroutineObjectBase, ICoroutine<T, R>
    {
        public Func<T, R, IEnumerator> Routine { get; private set; }

        public override event Action OnFinished;

        public CoroutineObject(MonoBehaviour owner, Func<T, R, IEnumerator> routine) : base(owner)
        {
            Routine = routine;
        }

        private IEnumerator Process(T arg1, R arg2)
        {
            yield return Routine.Invoke(arg1, arg2);

            Coroutine = null;

            OnFinished?.Invoke();
        }

        public void Start(T arg1, R arg2)
        {
            base.Reset();
            Stop();
            Coroutine = Owner.StartCoroutine(Process(arg1, arg2));
        }
    }
}
