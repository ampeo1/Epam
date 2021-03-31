using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TimeStruct
{
    /// <summary>
    /// Represents time.
    /// </summary>
    public readonly struct Time : IEquatable<Time>, IComparable<Time>, IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// This constructor convert minutes in format hours[0..23] and minutes[0..59].
        /// </summary>
        /// <param name="minutes">minutes format [int.Min..int.Max].</param>
        public Time(int minutes)
        {
            minutes %= 1440; // Threshold value. 24 * 60.
            this.Hours = minutes / 60;
            this.Minutes = minutes % 60;
            if (this.Minutes < 0)
            {
                this.Minutes += 60;
                this.Hours += 23;
            }

            if (this.Hours < 0)
            {
                this.Hours += 24;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// This constructor convert minutes in format hours[0..23] and minutes[0..59].
        /// </summary>
        /// <param name="hours">Hours.</param>
        /// <param name="minutes">Minutes.</param>
        public Time(int hours, int minutes)
            : this((hours * 60) + minutes)
        {
        }

        /// <summary>
        /// Gets hours.
        /// </summary>
        public int Hours
        {
            get;
        }

        /// <summary>
        /// Gets minutes.
        /// </summary>
        public int Minutes
        {
            get;
        }

        /// <summary>
        /// Add minutes to the object.
        /// </summary>
        /// <param name="time">Time object.</param>
        /// <param name="minutes">Minutes which need subtract add.</param>
        /// <returns>The sum of two time classes.</returns>
        /// <example>
        /// 12:45 + 1:35 = 14:20.
        /// </example>
        public static Time operator +(Time time, int minutes)
        {
            return new Time((60 * time.Hours) + time.Minutes + minutes);
        }

        /// <summary>
        /// Subtract minutes from the time object.
        /// </summary>
        /// <param name="time">Time object.</param>
        /// <param name="minutes">Minutes which need subtract.</param>
        /// <returns>The difference of two time classes.</returns>
        /// <example>
        /// 12:45 - 1:35 = 11:10.
        /// </example>
        public static Time operator -(Time time, int minutes)
        {
            return new Time((60 * time.Hours) + time.Minutes - minutes);
        }

        /// <summary>
        /// Determines whether time objects are equal.
        /// </summary>
        /// <param name="left">Left-hand side operand.</param>
        /// <param name="right">Right-hand side operand.</param>
        /// <returns>true if left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether time objects are not equal.
        /// </summary>
        /// <param name="left">Left-hand side operand.</param>
        /// <param name="right">Right-hand side operand.</param>
        /// <returns>true if left and right are not equal; otherwise, false.</returns>
        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if the left operand is greater than right.
        /// </summary>
        /// <param name="left">Left-hand side operand.</param>
        /// <param name="right">Right-hand side operand.</param>
        /// <returns>true if left is greater than right; otherwise, false.</returns>
        public static bool operator >(Time left, Time right)
        {
            if (left.Hours > right.Hours)
            {
                return true;
            }

            return left.Hours == right.Hours && left.Minutes > right.Minutes;
        }

        /// <summary>
        /// Checks if the left operand is less than right.
        /// </summary>
        /// <param name="left">Left-hand side operand.</param>
        /// <param name="right">Right-hand side operand.</param>
        /// <returns>true if left is less than right; otherwise, false.</returns>
        public static bool operator <(Time left, Time right)
        {
            if (left.Hours < right.Hours)
            {
                return true;
            }

            return left.Hours == right.Hours && left.Minutes < right.Minutes;
        }

        /// <summary>
        /// Checks if the left operand equal or greater than right.
        /// </summary>
        /// <param name="left">Left-hand side operand.</param>
        /// <param name="right">Right-hand side operand.</param>
        /// <returns>true if left is equal or greater than right; otherwise, false.</returns>
        public static bool operator >=(Time left, Time right)
        {
            if (left.Hours > right.Hours)
            {
                return true;
            }

            return left.Hours == right.Hours && left.Minutes >= right.Minutes;
        }

        /// <summary>
        /// Checks if the left operand equal or less than right.
        /// </summary>
        /// <param name="left">Left-hand side operand.</param>
        /// <param name="right">Right-hand side operand.</param>
        /// <returns>true if left is equal or less than right; otherwise, false.</returns>
        public static bool operator <=(Time left, Time right)
        {
            if (left.Hours < right.Hours)
            {
                return true;
            }

            return left.Hours == right.Hours && left.Minutes <= right.Minutes;
        }

        /// <summary>
        /// Add minutes to the object.
        /// </summary>
        /// <param name="time">Time object.</param>
        /// <param name="minutes">Minutes which need subtract add.</param>
        /// <returns>The sum of two time classes.</returns>
        /// <example>
        /// 12:45 + 1:35 = 14:20.
        /// </example>
        public static Time Add(Time time, int minutes)
        {
            return time + minutes;
        }

        /// <summary>
        /// Subtract minutes from the time object.
        /// </summary>
        /// <param name="time">Time object.</param>
        /// <param name="minutes">Minutes which need subtract.</param>
        /// <returns>The difference of two time classes.</returns>
        /// <example>
        /// 12:45 - 1:35 = 11:10.
        /// </example>
        public static Time Subtract(Time time, int minutes)
        {
            return time - minutes;
        }

        /// <summary>
        /// convert time in format 02:12.
        /// </summary>
        /// <returns>time format 02:12.</returns>
        public override string ToString()
        {
            StringBuilder timeFormat = new StringBuilder();
            if (this.Hours < 10)
            {
                timeFormat.Append("0");
            }

            timeFormat.Append(this.Hours);
            timeFormat.Append(":");
            if (this.Minutes < 10)
            {
                timeFormat.Append("0");
            }

            timeFormat.Append(this.Minutes);

            return timeFormat.ToString();
        }

        /// <summary>
        /// Calculates hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return this.Minutes ^ this.Hours;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>True if are equal otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Time)
            {
                return this.Equals((Time)obj);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">Other object.</param>
        /// <returns>True if are equal otherwise false.</returns>
        public bool Equals(Time other)
        {
            if (other.GetHashCode() != this.GetHashCode())
            {
                return false;
            }

            return other.Hours == this.Hours && other.Minutes == this.Minutes;
        }

        /// <summary>
        /// Compares objects.
        /// </summary>
        /// <param name="other">The object to compare with.</param>
        /// <returns>1 if this object greater than other; 0 if this and other object are equal; -1 if this object less than other.</returns>
        public int CompareTo([AllowNull] Time other)
        {
            if (this < other)
            {
                return -1;
            }

            if (this > other)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Compares objects.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>1 if this object greater than other; 0 if this and other object are equal; -1 if this object less than other.</returns>
        /// <exception cref="ArgumentException">Throw when <see cref="obj"/> not Time class.</exception>
        public int CompareTo(object obj)
        {
            if (obj is Time)
            {
                return this.CompareTo((Time)obj);
            }
            else
            {
                throw new ArgumentException($"{obj}");
            }
        }
    }
}
