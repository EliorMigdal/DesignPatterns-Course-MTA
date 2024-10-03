using Model.CustomeData;
using FacebookWrapper.ObjectModel;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Drawing;
using Model.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;

namespace Model.PanelDecorator.Types
{
    public class EventDecorator : IPanelDecorator
    {
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

        public EventData EventData { get; set; }

        public EventDecorator(EventAdapter i_EventWrapper)
        {
            EventData = i_EventWrapper.EventData;
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
                    new ColumnStyle(SizeType.Percent, 25F),
                    new ColumnStyle(SizeType.Percent, 25F),
                    new ColumnStyle(SizeType.Percent, 25F),
                    new ColumnStyle(SizeType.Percent, 25F)
                },
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            TableLayoutPanel innerTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                RowStyles =
                {
                    new ColumnStyle(SizeType.Percent, 80F),
                    new ColumnStyle(SizeType.Percent, 20F)
                },
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            initializeEventPicture(ref innerTable);
            initializeEventDate(ref innerTable);

            tableLayoutPanel.Controls.Add(innerTable, 0, 0);

            return tableLayoutPanel;
        }

        private void initializeEventPicture(ref TableLayoutPanel io_Panel)
        {
            PictureBox pictureBox = new PictureBox
            {
                ImageLocation = string.Empty,
                SizeMode = PictureBoxSizeMode.Zoom,
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
                Text = $"Date: {EventData.StartTime}",
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
                    new RowStyle(SizeType.Percent, 80F),
                    new RowStyle(SizeType.Percent, 20F)
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
                Text = EventData.Location,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            innerTable.Controls.Add(map, 0, 0);
            innerTable.Controls.Add(eventLabel, 0, 1);
            
            io_Panel.Controls.Add(innerTable, 1, 0);
        }

        private void initializeInfoColumn(ref TableLayoutPanel io_Panel)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            Label titleLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = $"Event: {EventData.Name}",
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            Label descriptionLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = $"Description: {EventData.Description}",
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            Label hostsLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = $"Host: {EventData.HostName}",
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            Label durationLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = $"Duration: {EventData.EndTime - EventData.StartTime}",
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            flowLayoutPanel.Controls.Add(titleLabel);
            flowLayoutPanel.Controls.Add(hostsLabel);
            flowLayoutPanel.Controls.Add(durationLabel);
            flowLayoutPanel.Controls.Add(descriptionLabel);

            io_Panel.Controls.Add(flowLayoutPanel, 2, 0);
        }

        private void initializeFriendsColumn(ref TableLayoutPanel io_Panel)
        {
            TableLayoutPanel outerPanel = new TableLayoutPanel
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

            Label attendingInfo = new Label
            {
                Text = $"Attending: {EventData.Attending}{Environment.NewLine}Interested: {EventData.Interested}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            ListBox friendsAttending = new ListBox
            {
                SelectionMode = SelectionMode.None,
                DisplayMember = "Name",
                Dock = DockStyle.Fill
            };

            foreach (EventData.Attendee atendee in EventData.Attendees)
            {
                friendsAttending.Items.Add(atendee);
            }

            outerPanel.Controls.Add(attendingInfo, 0, 0);
            outerPanel.Controls.Add(friendsAttending, 0, 1);

            io_Panel.Controls.Add(outerPanel, 3, 0);
        }
    }
}