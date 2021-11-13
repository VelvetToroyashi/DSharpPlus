// This file is part of the DSharpPlus project.
//
// Copyright (c) 2015 Mike Santiago
// Copyright (c) 2016-2021 DSharpPlus Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

#pragma warning disable 0649

using System;
using Newtonsoft.Json;

namespace DSharpPlus.Lavalink.Entities
{
    internal class LavalinkState
    {
        [JsonIgnore]
        public virtual DateTimeOffset Time => Utilities.GetDateTimeOffsetFromMilliseconds(this._time);
        [JsonProperty("time")]
        private readonly long _time;

        [JsonIgnore]
        public virtual TimeSpan Position => TimeSpan.FromMilliseconds(this._position);
        [JsonProperty("position")]
        private readonly long _position;
    }

    /// <summary>
    /// Represents current state of given player.
    /// </summary>
    public class LavalinkPlayerState
    {
        /// <summary>
        /// Gets the timestamp at which this state was last updated.
        /// </summary>
        public virtual DateTimeOffset LastUpdate { get; internal set; }

        /// <summary>
        /// Gets the current playback position.
        /// </summary>
        public virtual TimeSpan PlaybackPosition { get; internal set; }

        /// <summary>
        /// Gets the currently-played track.
        /// </summary>
        public virtual LavalinkTrack CurrentTrack { get; internal set; }
    }

    internal class LavalinkStats
    {
        [JsonProperty("playingPlayers")]
        public virtual int ActivePlayers { get; set; }

        [JsonProperty("players")]
        public virtual int TotalPlayers { get; set; }

        [JsonIgnore]
        public virtual TimeSpan Uptime => TimeSpan.FromMilliseconds(this._uptime);
        [JsonProperty("uptime")]
        private readonly long _uptime;

        [JsonProperty("cpu")]
        public virtual CpuStats Cpu { get; set; }

        [JsonProperty("memory")]
        public virtual MemoryStats Memory { get; set; }

        [JsonProperty("frameStats")]
        public virtual FrameStats Frames { get; set; }

        internal class CpuStats
        {
            [JsonProperty("cores")]
            public virtual int Cores { get; set; }

            [JsonProperty("systemLoad")]
            public virtual double SystemLoad { get; set; }

            [JsonProperty("lavalinkLoad")]
            public virtual double LavalinkLoad { get; set; }
        }

        internal class MemoryStats
        {
            [JsonProperty("reservable")]
            public virtual long Reservable { get; set; }

            [JsonProperty("used")]
            public virtual long Used { get; set; }

            [JsonProperty("free")]
            public virtual long Free { get; set; }

            [JsonProperty("allocated")]
            public virtual long Allocated { get; set; }
        }

        internal class FrameStats
        {
            [JsonProperty("sent")]
            public virtual int Sent { get; set; }

            [JsonProperty("nulled")]
            public virtual int Nulled { get; set; }

            [JsonProperty("deficit")]
            public virtual int Deficit { get; set; }
        }
    }

    /// <summary>
    /// Represents statistics of Lavalink resource usage.
    /// </summary>
    public class LavalinkStatistics
    {
        /// <summary>
        /// Gets the number of currently-playing players.
        /// </summary>
        public virtual int ActivePlayers { get; private set; }

        /// <summary>
        /// Gets the total number of players.
        /// </summary>
        public virtual int TotalPlayers { get; private set; }

        /// <summary>
        /// Gets the node uptime.
        /// </summary>
        public virtual TimeSpan Uptime { get; private set; }

        /// <summary>
        /// Gets the number of CPU cores available.
        /// </summary>
        public virtual int CpuCoreCount { get; private set; }

        /// <summary>
        /// Gets the total % of CPU resources in use on the system.
        /// </summary>
        public virtual double CpuSystemLoad { get; private set; }

        /// <summary>
        /// Gets the total % of CPU resources used by lavalink.
        /// </summary>
        public virtual double CpuLavalinkLoad { get; private set; }

        /// <summary>
        /// Gets the amount of reservable RAM, in bytes.
        /// </summary>
        public virtual long RamReservable { get; private set; }

        /// <summary>
        /// Gets the amount of used RAM, in bytes.
        /// </summary>
        public virtual long RamUsed { get; private set; }

        /// <summary>
        /// Gets the amount of free RAM, in bytes.
        /// </summary>
        public virtual long RamFree { get; private set; }

        /// <summary>
        /// Gets the amount of allocated RAM, in bytes.
        /// </summary>
        public virtual long RamAllocated { get; private set; }

        /// <summary>
        /// Gets the average number of sent frames per minute.
        /// </summary>
        public virtual int AverageSentFramesPerMinute { get; private set; }

        /// <summary>
        /// Gets the average number of frames that were sent as null per minute.
        /// </summary>
        public virtual int AverageNulledFramesPerMinute { get; private set; }

        /// <summary>
        /// Gets the average frame deficit per minute.
        /// </summary>
        public virtual int AverageDeficitFramesPerMinute { get; private set; }

        internal bool _updated;

        internal LavalinkStatistics()
        {
            this._updated = false;
        }

        internal void Update(LavalinkStats newStats)
        {
            if (!this._updated)
                this._updated = true;

            this.ActivePlayers = newStats.ActivePlayers;
            this.TotalPlayers = newStats.TotalPlayers;
            this.Uptime = newStats.Uptime;

            this.CpuCoreCount = newStats.Cpu.Cores;
            this.CpuSystemLoad = newStats.Cpu.SystemLoad;
            this.CpuLavalinkLoad = newStats.Cpu.LavalinkLoad;

            this.RamReservable = newStats.Memory.Reservable;
            this.RamUsed = newStats.Memory.Used;
            this.RamFree = newStats.Memory.Free;
            this.RamAllocated = newStats.Memory.Allocated;
            this.RamReservable = newStats.Memory.Reservable;

            this.AverageSentFramesPerMinute = newStats.Frames?.Sent ?? 0;
            this.AverageNulledFramesPerMinute = newStats.Frames?.Nulled ?? 0;
            this.AverageDeficitFramesPerMinute = newStats.Frames?.Deficit ?? 0;
        }
    }
}
