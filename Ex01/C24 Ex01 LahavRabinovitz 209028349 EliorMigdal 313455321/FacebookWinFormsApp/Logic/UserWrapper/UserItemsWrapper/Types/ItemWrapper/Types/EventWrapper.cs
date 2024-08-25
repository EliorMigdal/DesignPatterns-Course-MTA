using FacebookWrapper.ObjectModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using BasicFacebookFeatures.Data;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Logic.UserWrapper.UserItemsWrapper.Types.ItemWrapper.Types
{
    public class EventWrapper : IUserItemWrapper, IPanelViewable
    {
        public string Name { get; set; }
        public Event Event { get; set; }
        public EventData EventData { get; set; }
        public string Picture { get; set; }
        private Collection<Control> m_Controls;
        public Collection<Control> Controls
        {
            get
            {
                if (m_Controls == null)
                {
                    m_Controls = new Collection<Control>();
                    initializeControls();
                }

                return m_Controls;
            }
        }

        public EventWrapper(EventData i_EventData)
        {
            EventData = i_EventData;
            Name = i_EventData.Name;
            Picture = i_EventData.Picture;
        }

        public EventWrapper(Event i_Event)
        {
            Event = i_Event;
            Name = i_Event.Name;
            Picture = i_Event.PictureNormalURL;
        }

        private void initializeControls()
        {
            TableLayoutPanel tableLayoutPanel = initializeGrid();

            initializeLocation(ref tableLayoutPanel);
            initializeInfoColumn(ref tableLayoutPanel);
            initializeFriendsColumn(ref tableLayoutPanel);

            m_Controls.Add(tableLayoutPanel);
        }

        private TableLayoutPanel initializeGrid()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 20F),
                    new ColumnStyle(SizeType.Percent, 20F),
                    new ColumnStyle(SizeType.Percent, 40F),
                    new ColumnStyle(SizeType.Percent, 20F)
                },
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            TableLayoutPanel innerTable = generateTwoRowedColumn();

            initializeEventPicture(ref innerTable);
            initializeEventDate(ref innerTable);

            tableLayoutPanel.Controls.Add(innerTable, 0, 0);

            return tableLayoutPanel;
        }

        private void initializeEventPicture(ref TableLayoutPanel io_Panel)
        {
            PictureBox pictureBox = new PictureBox
            {
                ImageLocation = EventData.Picture, //ImageLocation = Event.PictureNormalURL,
                SizeMode = PictureBoxSizeMode.Normal,
                Dock = DockStyle.Fill,
                Size = new Size(60, 60),
                Margin = new Padding(5)
            };

            io_Panel.Controls.Add(pictureBox, 0, 0);
        }

        private void initializeEventDate(ref TableLayoutPanel io_Panel)
        {
            Label dateLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = $"Date: {EventData.StartTime}", //Text = $"Date: {Event.StartTime}",
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            io_Panel.Controls.Add(dateLabel, 0, 1);
        }

        private void initializeLocation(ref TableLayoutPanel io_Panel)
        {
            TableLayoutPanel innerTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 20F),
                    new RowStyle(SizeType.Percent, 80F)
                }
            };

            GMapControl map = new GMapControl
            {
                Dock = DockStyle.Fill,
                MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance,
                Position = new PointLatLng(32.046954, 34.761692),
                MinZoom = 0,
                MaxZoom = 18,
                Zoom = 12
            };

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(32.046954, 34.761692), GMarkerGoogleType.red);
            markersOverlay.Markers.Add(marker);
            map.Overlays.Add(markersOverlay);

            Label eventLabel = new Label
            {
                Text = EventData.Location, //Text = Event.Location,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            innerTable.Controls.Add(eventLabel, 0, 0);
            innerTable.Controls.Add(map, 0, 1);
            io_Panel.Controls.Add(innerTable, 1, 0);
        }

        private TableLayoutPanel generateTwoRowedColumn()
        {
            return new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 50F),
                    new RowStyle(SizeType.Percent, 50F)
                }
            };
        }

        private void initializeInfoColumn(ref TableLayoutPanel io_Panel)
        {
            TableLayoutPanel infoLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 25F),
                    new RowStyle(SizeType.Percent, 25F),
                    new RowStyle(SizeType.Percent, 25F),
                    new RowStyle(SizeType.Percent, 25F)
                }
            };

            Label titleLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = EventData.Name, //Text = Event.Name,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            Label descriptionLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = EventData.Description, //Event.Description,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            Label hostsLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = EventData.HostName, //Event.Owner.Name,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            Label durationLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = (EventData.EndTime - EventData.StartTime).ToString(), //(Event.EndTime - Event.StartTime).ToString(),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            infoLayoutPanel.Controls.Add(titleLabel, 0, 0);
            infoLayoutPanel.Controls.Add(hostsLabel, 0, 1);
            infoLayoutPanel.Controls.Add(durationLabel, 0, 2);
            infoLayoutPanel.Controls.Add(descriptionLabel, 0, 3);

            io_Panel.Controls.Add(infoLayoutPanel, 2, 0);
        }

        private void initializeFriendsColumn(ref TableLayoutPanel io_Panel)
        {
            TableLayoutPanel outerPanel = generateTwoRowedColumn();

            Label attendingInfo = new Label
            {
                Text = $"Attending: {EventData.Attendees.Count}{Environment.NewLine}Interested: {EventData.Attendees.Count}",
                //Text = $"Attending: {Event.AttendingCount}{Environment.NewLine}Interested: {Event.InterestedCount}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            ListBox friendsAttending = new ListBox
            {
                SelectionMode = SelectionMode.None,
                DisplayMember = "Name"
            };

            foreach (EventData.Attendee atendee in EventData.Attendees)
            {
                friendsAttending.Items.Add(atendee);
            }

            //foreach (User user in Event.InvitedUsers)
            //{
            //    friendsAttending.Items.Add(user.Name);
            //}

            outerPanel.Controls.Add(attendingInfo, 0, 0);
            outerPanel.Controls.Add(friendsAttending, 0, 1);

            io_Panel.Controls.Add(outerPanel, 3, 0);
        }
    }
}
