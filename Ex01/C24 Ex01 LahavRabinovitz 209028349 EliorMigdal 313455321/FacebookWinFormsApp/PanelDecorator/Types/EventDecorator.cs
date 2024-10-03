using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Properties;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using BasicFacebookFeatures.TableDecorator;
using BasicFacebookFeatures.TableDecorator.Decorators;
using System.Collections.Generic;
using System.Linq;

namespace BasicFacebookFeatures.PanelDecorator.Types
{
    public class EventDecorator : IPanelDecorator
    {
        private readonly EventData r_EventData;
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

        public EventDecorator(EventAdapter i_EventWrapper)
        {
            r_EventData = i_EventWrapper.EventData;
        }

        private void initializeControls()
        {
            IGrid outerGrid = new CoreGrid(1, 4);

            initializePictureColumn(outerGrid);
            initializeLocationColumn(outerGrid);
            initializeInfoColumn(outerGrid);
            initializeAttendingColumn(outerGrid);

            m_Controls.Add(outerGrid.Grid);
        }

        private void initializePictureColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new LabelsGrid
                (
                    new PicturesGrid
                    (
                        new RatioGrid
                        (
                            new CoreGrid(2, 1), 
                            new List<(int, float)>
                            {
                                (1, 80F), (2, 20F)
                            }
                        ),
                        new List<(System.Drawing.Image i_Source, int i_Height, int i_Width)>
                        {
                            (Resources.summerbeach, 60, 60)
                        }
                    ),
                    new Collection<string>
                    {
                        $"Date: {r_EventData.StartTime}"
                    }
                ).Grid, 0, 0
            );
        }

        private void initializeLocationColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new LabelsGrid
                (
                    new GMapGrid
                    (
                        new RatioGrid
                        (
                            new CoreGrid(2, 1),
                            new List<(int, float)>
                            {
                                (1, 80F), (2, 20F) 
                            }
                        ),

                        (32.046954F, 34.761692F)
                    ),
                    new Collection<string>
                    {
                        $"Date: {r_EventData.StartTime}"
                    }
                ).Grid, 1, 0
            );
        }

        private void initializeInfoColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new LabelsGrid
                (
                    new CoreGrid(),
                    new Collection<string>
                    {
                        $"Event: {r_EventData.Name}",
                        $"Description: {r_EventData.Description}",
                        $"Host: {r_EventData.HostName}",
                        $"Duration: {r_EventData.EndTime - r_EventData.StartTime}",
                    }
                ).Grid, 2, 0
            );
        }

        private void initializeAttendingColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new ListBoxGrid
                (
                    new LabelsGrid
                    (
                        new CoreGrid(2, 1), new Collection<string>
                        {
                            $"Attending: {r_EventData.Attending}{Environment.NewLine}" +
                            $"Interested: {r_EventData.Interested}"
                        }
                    ), 
                    r_EventData.Attendees.Select(atendee => atendee.Name).ToList()
                ).Grid, 3, 0
            );
        }
    }
}
