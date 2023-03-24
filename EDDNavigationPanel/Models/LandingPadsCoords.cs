using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace EDDNavigationPanel.Models
{
    /// <summary>
    /// Manages the landing pads coordinates resource.
    /// </summary>
    public class LandingPadsCoords
    {
        #region fields
        private const string _resourceName = "LandingPadsCoords.csv";
        private const char _csvSeparator = ';';
        private const string _headerNameStationType = "StationType";
        private const string _headerNameCoordX = "FromCenterX";
        private const string _headerNameCoordY = "FromCenterY";
        private Dictionary<StationType, List<Vector>> _padCoordinates;
        private int _indexStationType, _indexCoordX, _indexCoordY;
        #endregion fields

        #region ctor
        public LandingPadsCoords()
        {
            _padCoordinates = InitializeCoordinates();
        }
        #endregion ctor

        #region properties
        public StationType[] StationTypes { get => _padCoordinates.Keys.ToArray(); }
        #endregion properties

        #region methods
        /// <summary>
        /// Retrieve the coordinates for a landing pad in a station type.
        /// </summary>
        /// <param name="stationType">The station type.</param>
        /// <param name="padNumber">The landing pad number.</param>
        /// <returns>A <see cref="Vector"/> with relative coordinates of the landing pad.</returns>
        public Vector Get(StationType stationType, int padNumber)
        {
            var stationCoords = _padCoordinates[stationType];
            if (padNumber < 1 || padNumber > stationCoords.Count)
                throw new ArgumentOutOfRangeException(nameof(padNumber));

            return stationCoords[padNumber - 1];
        }

        /// <summary>
        /// Retrieve the number of landing pads for a station type.
        /// </summary>
        /// <param name="stationType">The station type.</param>
        /// <returns>The number of pads.</returns>
        public int GetPadCount(StationType stationType)
        {
            return _padCoordinates[stationType].Count();
        }

        /// <summary>
        /// Load LandingPads Coordinates from resource into cache dictionary.
        /// </summary>
        /// <returns>The dictionary with cached coordinates.</returns>
        private Dictionary<StationType, List<Vector>> InitializeCoordinates()
        {
            var padCoordinates = new Dictionary<StationType, List<Vector>>();
            List<string> header = null;

            foreach (var line in ResourceData())
            {
                var data = line.Split(_csvSeparator);
                if (header == null)
                {
                    header = data.ToList();
                    _indexStationType = header.IndexOf(_headerNameStationType);
                    _indexCoordX = header.IndexOf(_headerNameCoordX);
                    _indexCoordY = header.IndexOf(_headerNameCoordY);
                    continue;
                }
                var stationType = (StationType)Enum.Parse(typeof(StationType), data[_indexStationType]);
                var relX = double.Parse(data[_indexCoordX], System.Globalization.CultureInfo.InvariantCulture);
                var relY = double.Parse(data[_indexCoordY], System.Globalization.CultureInfo.InvariantCulture);
                var coord = new Vector(relX, relY);
                if (padCoordinates.ContainsKey(stationType) == false)
                    padCoordinates[stationType] = new List<Vector>();
                padCoordinates[stationType].Add(coord);
            }
            return padCoordinates;
        }

        /// <summary>
        /// Enumerate LandingPads coordinates from resource.
        /// </summary>
        /// <returns>Yield return data line per line.</returns>
        private IEnumerable<string> ResourceData()
        {
            using (var stream = ResourcesManager.GetResourceStream(_resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (reader.EndOfStream == false)
                    yield return reader.ReadLine();
            }
        }
        #endregion methods
    }
}
