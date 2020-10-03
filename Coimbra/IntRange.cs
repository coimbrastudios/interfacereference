﻿using Coimbra.Attributes;
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coimbra
{
    /// <summary>
    ///     Stores a range between 2 ints.
    /// </summary>
    [Serializable]
    public struct IntRange : IEquatable<IntRange>
    {
        [FormerlySerializedAs("m_Min")] [Summary(nameof(Min))]
        [SerializeField] private int _min;
        [FormerlySerializedAs("m_Max")] [Summary(nameof(Max))]
        [SerializeField] private int _max;

        /// <param name="a"> The <see cref="Min"/> or <see cref="Max"/> value. </param>
        /// <param name="b"> The <see cref="Min"/> or <see cref="Max"/> value. </param>
        [PublicAPI]
        public IntRange(int a, int b = 0)
        {
            _min = a < b ? a : b;
            _max = a > b ? a : b;
        }

        /// <summary>
        ///     The diff between <see cref="Max"/> and <see cref="Min"/>.
        /// </summary>
        [PublicAPI]
        public int Lenght => Max - Min;

        [PublicAPI]
        public int Max => _max;

        [PublicAPI]
        public int Min => _min;

        /// <summary>
        ///     Returns a random integer number between <see cref="Min"/> [inclusive] and <see cref="Max"/> [exclusive].
        /// </summary>
        [PublicAPI]
        public int RandomExclusive => UnityEngine.Random.Range(Min, Max);

        /// <summary>
        ///     Returns a random integer number between <see cref="Min"/> [inclusive] and <see cref="Max"/> [inclusive].
        /// </summary>
        [PublicAPI]
        public int RandomInclusive => UnityEngine.Random.Range(Min, Max + 1);

        /// <summary>
        ///     The sum of <see cref="Min"/> and <see cref="Max"/>.
        /// </summary>
        [PublicAPI]
        public int Sum => Min + Max;

        [PublicAPI] [Pure]
        public static implicit operator FloatRange(IntRange value)
        {
            return new FloatRange(value.Min, value.Max);
        }

        [PublicAPI] [Pure]
        public static implicit operator Vector2(IntRange value)
        {
            return new Vector2(value.Min, value.Max);
        }

        [PublicAPI] [Pure]
        public static implicit operator Vector2Int(IntRange value)
        {
            return new Vector2Int(value.Min, value.Max);
        }

        [PublicAPI] [Pure]
        public static implicit operator IntRange(Vector2Int value)
        {
            return new IntRange(value.x, value.y);
        }

        [PublicAPI] [Pure]
        public static bool operator ==(IntRange a, IntRange b)
        {
            return a.Min == b.Min && a.Max == b.Max;
        }

        [PublicAPI] [Pure]
        public static bool operator !=(IntRange a, IntRange b)
        {
            return !(a == b);
        }

        /// <summary>
        ///     Returns true if the value is between min [inclusive] and max [exclusive].
        /// </summary>
        [PublicAPI] [Pure]
        public bool ContainsExclusive(int value)
        {
            return value >= Min && value < Max;
        }

        /// <summary>
        ///     Returns true if the value is between min [inclusive] and max [exclusive].
        /// </summary>
        [PublicAPI] [Pure]
        public bool ContainsExclusive(float value)
        {
            return value >= Min && value < Max;
        }

        /// <summary>
        ///     Returns true if the value is between min [inclusive] and max [inclusive].
        /// </summary>
        [PublicAPI] [Pure]
        public bool ContainsInclusive(int value)
        {
            return value >= Min && value <= Max;
        }

        /// <summary>
        ///     Returns true if the value is between min [inclusive] and max [inclusive].
        /// </summary>
        [PublicAPI] [Pure]
        public bool ContainsInclusive(float value)
        {
            return value >= Min && value <= Max;
        }

        [PublicAPI] [Pure]
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (base.Equals(obj))
            {
                return true;
            }

            switch (obj)
            {
                case IntRange _:
                case Vector2Int _:

                    return this == (IntRange)obj;

                case FloatRange _:
                case Vector2 _:

                    return this == (FloatRange)obj;

                default:

                    return false;
            }
        }

        [PublicAPI] [Pure]
        public override int GetHashCode()
        {
            return (Min.GetHashCode() + Max.GetHashCode()) * 37;
        }

        [NotNull] [PublicAPI] [Pure]
        public override string ToString()
        {
            return $"[{Min}, {Max}]";
        }

        [PublicAPI] [Pure]
        public bool Equals(IntRange other)
        {
            return this == other;
        }
    }
}