using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Forms;
using BasicFacebookFeatures.CustomeData;
using System.Drawing;
using BasicFacebookFeatures.Properties;
using BasicFacebookFeatures.TableDecorator.Decorators;
using BasicFacebookFeatures.TableDecorator;

namespace BasicFacebookFeatures.PanelDecorator.Types
{
    public class FriendDecorator : IPanelDecorator
    {
        private readonly Friend r_Friend;
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

        public FriendDecorator(FriendAdapter i_FriendAdapter)
        {
            r_Friend = i_FriendAdapter.Friend;
        }

        private void initializeControls()
        {
            IGrid outerGrid = new RatioGrid(new CoreGrid(1, 3), null, new List<(int, float)>
            {
                (1, 25F), (2, 50F), (3, 25F)
            });

            initializeFriendInformationColumn(outerGrid);
            initializeFriendWallColumn(outerGrid);
            initializeFriendPicturesColumn(outerGrid);

            m_Controls.Add(outerGrid.Grid);
        }

        private void initializeFriendInformationColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new ButtonGrid
                (
                    new PicturesGrid
                    (
                        new LabelsGrid
                        (
                            new RatioGrid
                            (
                                new CoreGrid(3, 1),
                                new List<(int, float)>
                                {
                                    (1, 25F), (2, 50F), (3, 25F)
                                }
                            ),
                            new Collection<string>
                            {
                                $"Name: {r_Friend.Name}"
                            }
                        ),
                        new List<(Image i_Source, int i_Height, int i_Width)>
                        {
                            (Resources.batman, 60, 60)
                        }
                    ),
                    "Close Friend"
                ).Grid
            );
        }

        private void initializeFriendWallColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new ListBoxGrid
                (
                    new CoreGrid(),
                    r_Friend.Posts
                ).Grid
            );
        }

        private void initializeFriendPicturesColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new PicturesGrid
                (
                    new CoreGrid(),
                    new List<(Image i_Source, int i_Height, int i_Width)>
                    {
                        (Resources.summerbeach, 60, 60),
                        (Resources.batman, 60, 60)
                    }
                ).Grid
            );
        }
    }
}
