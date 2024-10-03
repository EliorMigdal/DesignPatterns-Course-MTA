using BasicFacebookFeatures.CustomeData;
using BasicFacebookFeatures.Logic.UserProxy.UserItemsAdapter.Types.ItemAdapter.Types;
using BasicFacebookFeatures.TableDecorator;
using BasicFacebookFeatures.TableDecorator.Decorators;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using BasicFacebookFeatures.Properties;

namespace BasicFacebookFeatures.PanelDecorator.Types
{
    public class LikedPageDecorator : IPanelDecorator
    {
        private readonly LikedPageData r_LikedPagesData;
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

        public LikedPageDecorator(LikedPageAdapter i_PageAdapter)
        {
            r_LikedPagesData = i_PageAdapter.LikedPageData;
        }

        private void initializeControls()
        {
            IGrid outerGrid = new CoreGrid(1, 2);

            initializePagePictureColumn(outerGrid);
            initializePageWallColumn(outerGrid);

            m_Controls.Add(outerGrid.Grid);
        }

        private void initializePagePictureColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new PicturesGrid
                (
                    new CoreGrid(),
                    new List<(Image i_Source, int i_Height, int i_Width)>
                    {
                        (Resources.tech, 60, 60)
                    }
                ).Grid
            );
        }

        private void initializePageWallColumn(IGrid i_OuterGrid)
        {
            i_OuterGrid.Grid.Controls.Add
            (
                new ListBoxGrid
                (
                    new CoreGrid(),
                    r_LikedPagesData.Posts
                ).Grid
            );
        }
    }
}
