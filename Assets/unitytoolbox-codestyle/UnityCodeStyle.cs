/*
 * Code Style Guide for the Unity projects
 * Inspired by:
 * https://github.com/raywenderlich/c-sharp-style-guide#classes--interfaces
 * https://github.com/elhispano/Unity-code-convention/blob/master/CodeConventionForUnity.cs
 * https://marketplace.visualstudio.com/items?itemName=ChrisDahlberg.StyleCop
 */

// 1. Pragma
#pragma warning disable

// 2. Namespace
namespace Unity.Code.Style
{
    // 3. Using: only keep meaningful ones and in alphabetical order
    using System;
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;

    // 4. Interfaces
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "No need")]
    public interface ISomeInterface<T>
    {
    }

    // 5. Classes: one public class per .cs file
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "No need")]
    public class UnityCodeStyle : MonoBehaviour
    {
        /*
         * a. Fields and Properties
         * Keywords order: [Unity tags] [private/protected/public] [const] [static] [readonly] [type]
         * Fields should be assigned a default value
         *    constants and static readonly fields
         *    private fields
         *    actions
         *    events/delegates
         *    properties 
         * For booleans, use a question format (eg isActive)
         */
        public const int SomeConstInt = 0;
        public static readonly int SomeStaticReadonlyInt = 42;

        [SerializeField] private int someNumber1 = 1;
        private int someNumber2 = 2;
        private float someFloat1 = 3.0f;
        private float someFloat2 = 4.0f;
        private float someFloat3 = 5.0f;
        private bool isActive = true;

        private Action<int> someAction;
     
        public delegate void SomeDelegate(int number);

        public event SomeDelegate OnSomeDelegateEvent;

        public int SomeRandomProperty { get; set; }

        public int SomeNumber2
        {
            get
            {
                this.someNumber2 = 42;
                return this.someNumber2;
            }

            set
            {
                this.someNumber2 = value;
            }
        }

        /*
         * b. Callbacks
         */
        public void OnSomethingHappened()
        {
        }

        /*
         * c. Methods
         * Method names should be descriptive
         * Order by public, protected and private
         */
        public void ComputeScoreAndUploadToServer(int someParameter)
        {
            // Switch example
            switch (someParameter)
            {
                case 0:
                    break;

                case 1:
                    break;

                default:
                    break;
            }

            // Acronyms should be treated as words
            int xmlAcronymExample = 0;
            xmlAcronymExample += 1;

            // When having multiple conditions spread them over multiple lines
            if (true
                && false
                && false)
            {
            }

            // Spacing and parentheses example 
            for (int i = 0; i < 10; ++i)
            {
                int a = (10 + 3) * 4;
            }

            // Start coroutines by their method name so they can be found via reference
            Coroutine coroutine = StartCoroutine(CoroutineExample());

            // Stop coroutines using a cached reference
            StopCoroutine(coroutine);
        }
        
        // Coroutines are just methods, treat them as such
        private IEnumerator CoroutineExample()
        {
            yield return null;
        }

        /*
         * d. Unity methods
         * Delete them if empty and add new ones in the proper place based on https://docs.unity3d.com/Manual/ExecutionOrder.html
         */
        private void Awake()
        {
            // use this for internal setup
        }

        private void OnEnable()
        {
            // use this for external setup (eg caching components, etc)
        }

        private void Start()
        {
        }

        private void FixedUpdate()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
        }

        private void OnCollisionEnter(Collision collision)
        {
        }

        private void Update()
        {
        }

        private void LateUpdate()
        {
        }

        private void OnApplicationPause(bool pause)
        {
        }

        private void OnApplicationQuit()
        {
        }

        private void OnDisable()
        {
        }

        private void OnDestroy()
        {
        }

        // e. Structs
        public struct NestedStruct
        {
            public int SomeNestedInt;
        }
    }
}

// 6. Add one empty line at the end of the file
