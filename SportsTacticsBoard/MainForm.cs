using System.Collections.Generic;
using System.Linq;
using Eto.Drawing;
using Eto.Forms;
using SportsTacticsBoard.Resources;

namespace SportsTacticsBoard
{
    public class MainForm : Form
    {
        private ResourceManager ResourceManager { get; }

        public MainForm(ResourceManager resourceManager)
        {
            ResourceManager = resourceManager;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            ClientSize = new Size(767, 553);
            InitilizeMenu();
            InitilizeToolbar();
        }

        private void InitilizeMenu()
        {
            var menu = new MenuBar()
            {
                Items =
                {
                    new ButtonMenuItem()
                    {
                        Text = ResourceManager.LocalizationResource.MenuSequence,
                        Items =
                        {
                            new ButtonMenuItem  //New
                            {
                                Text = ResourceManager.LocalizationResource.MenuNewSequence,
                                Image = ResourceManager.ImagesResource.NewDocumentHs,
                                Command = /* ToDo: Add NewSequence command */ null,
                                Shortcut = Application.Instance.CommonModifier | Keys.N
                            },
                            new ButtonMenuItem  //Open
                            {
                                Text = ResourceManager.LocalizationResource.MenuOpenSequence,
                                Image = ResourceManager.ImagesResource.OpenHs,
                                Command = /* ToDo: Add OpenSequence command */ null,
                                Shortcut = Application.Instance.CommonModifier | Keys.O
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem  //Export
                            {
                                Text = ResourceManager.LocalizationResource.MenuExport,
                                ToolTip = ResourceManager.LocalizationResource.MenuExportTooltip,
                                Command = /* ToDo: Add ExportSequence command */ null
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem  //Save
                            {
                                Text = ResourceManager.LocalizationResource.MenuSaveSequence,
                                Image = ResourceManager.ImagesResource.SaveHs,
                                Command = /* ToDo: Add SaveSequence command */ null,
                                Shortcut = Application.Instance.CommonModifier | Keys.S
                            },
                            new ButtonMenuItem  //Save As
                            {
                                Text = ResourceManager.LocalizationResource.MenuSaveSequenceAs,
                                Command = /* ToDo: Add SaveSequenceAs command */ null
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem  //Print
                            {
                                Text = ResourceManager.LocalizationResource.MenuPrint,
                                Command = /* ToDo: Add PrintSequence command */ null
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem  //Options
                            {
                                Text = ResourceManager.LocalizationResource.MenuOptions,
                                Command = /* ToDo: Add Options command */ null
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem  //Exit
                            {
                                Text = ResourceManager.LocalizationResource.MenuExit,
                                Command = new Command((sender, e) => Application.Instance.Quit())
                            }
                        }
                    },
                    new ButtonMenuItem
                    {
                        Text = ResourceManager.LocalizationResource.MenuLayout,
                        Tag = "Layout",
                        Items=
                        {
                            new ButtonMenuItem  //Copy
                            {
                                Text = ResourceManager.LocalizationResource.MenuCopy,
                                ToolTip = ResourceManager.LocalizationResource.MenuCopyTooltip,
                                Shortcut = Application.Instance.CommonModifier | Keys.C,
                                Command = /* ToDo: Add Copy command */ null
                            },
                            new ButtonMenuItem  //ExportSingle
                            {
                                Text = ResourceManager.LocalizationResource.MenuExportSingle,
                                Command = /* ToDo: Add ExportSingle command */ null
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem  //SaveCurrentLayout
                            {
                                Text = ResourceManager.LocalizationResource.MenuSaveCurrentLayout,
                                Command = /* ToDo: Add SaveCurrentLayout command */ null
                            },
                            new ButtonMenuItem  //RemoveSavedLayout
                            {
                                Text = ResourceManager.LocalizationResource.MenuRemoveSavedLayout,
                                Command = /* ToDo: Add RemoveSavedLayout command */ null
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem
                            {
                                Text = ResourceManager.LocalizationResource.MenuUserSavedLayouts,
                                Tag = "UserSavedLayouts"
                            },
                            new ButtonMenuItem
                            {
                                Text = ResourceManager.LocalizationResource.MenuCommonSavedLayouts,
                                Tag = "CommonSavedLayouts"
                            }
                        }
                    },
                    new ButtonMenuItem
                    {
                        Text = ResourceManager.LocalizationResource.MenuPlayingSurface,
                        Tag = "PlayingSurface",
                        Items =
                        {
                            new ButtonMenuItem  //ChangeSurfaceType
                            {
                                Text = ResourceManager.LocalizationResource.MenuChangePlayingSurfaceType,
                                Command = /* ToDo: Add ChangeSurfaceType command */ null
                            },
                            new SeparatorMenuItem(),
                            new ButtonMenuItem  //Orientation
                            {
                                Text = ResourceManager.LocalizationResource.MenuOrientation,
                                Tag = "Orientation"
                            },
                            new ButtonMenuItem  //ResetView
                            {
                                Text = ResourceManager.LocalizationResource.MenuResetView,
                                Command = /* ToDo: Add ResetView command */ null
                            }
                        }
                    }
                }
            };

            ((menu.Items.First(mi => (string)mi.Tag == "Layout") as ButtonMenuItem).Items.First(
                mi => (string)mi.Tag == "UserSavedLayouts") as ButtonMenuItem).Items.AddRange(LoadUserSavedLayouts());
            ((menu.Items.First(mi => (string)mi.Tag == "Layout") as ButtonMenuItem).Items.First(
                mi => (string)mi.Tag == "CommonSavedLayouts") as ButtonMenuItem).Items.AddRange(LoadCommonSavedLayouts());
            ((menu.Items.First(mi => (string)mi.Tag == "PlayingSurface") as ButtonMenuItem).Items.First(
                mi => (string)mi.Tag == "Orientation") as ButtonMenuItem).Items.AddRange(GetVerticalHorizontalRadioMenuItems());

            Menu = menu;
        }

        private IEnumerable<MenuItem> GetVerticalHorizontalRadioMenuItems()
        {
            var horizontal = new RadioMenuItem //Horizontal
            {
                Text = ResourceManager.LocalizationResource.MenuHorizontal,
                Tag = "Horizontal",
                Command = /* ToDo: Add SetOrientation(Horizontal) command */ null,
                Checked = true
            };
            var vertical = new RadioMenuItem(horizontal) //Vertical
            {
                Text = ResourceManager.LocalizationResource.MenuVertical,
                Tag = "Vertical",
                Command = /* ToDo: Add SetOrientation(Vertical) command */ null
            };
            return new[] {horizontal, vertical};
        }

        private IEnumerable<MenuItem> LoadUserSavedLayouts()
        {
            return new List<MenuItem>
            {
                new ButtonMenuItem
                {
                    Text = ResourceManager.LocalizationResource.NoSavedLayoutsMenuItemText,
                    Enabled = false
                }
            };
        }

        private IEnumerable<MenuItem> LoadCommonSavedLayouts()
        {
            return new List<MenuItem>
            {
                new ButtonMenuItem
                {
                    Text = ResourceManager.LocalizationResource.NoSavedLayoutsMenuItemText,
                    Enabled = false
                }
            };
        }

        private void InitilizeToolbar()
        {
            var toolbar = new ToolBar
            {
                Items =
                {
                    new ButtonToolItem  //GoToFirst
                    {
                        ToolTip = ResourceManager.LocalizationResource.GoToFirst,
                        Image = ResourceManager.ImagesResource.DataContainerMoveFirstHs,
                        Command = /* ToDo: Add GoToFirst command */ null
                    },
                    new ButtonToolItem  //Previous
                    {
                        ToolTip = ResourceManager.LocalizationResource.PreviousLayout,
                        Image = ResourceManager.ImagesResource.DataContainerMovePreviousHs,
                        Command = /* ToDo: Add GoToPrevious command */ null
                    },
                    //ToDo: create a text tool item to display sequence position
                    new ButtonToolItem {Text = "1/1", Enabled = false},
                    new ButtonToolItem  //Next
                    {
                        ToolTip = ResourceManager.LocalizationResource.NextLayout,
                        Image = ResourceManager.ImagesResource.DataContainerMoveNextHs,
                        Command = /* ToDo: Add GoToNext command */ null
                    },
                    new ButtonToolItem  //GoToLast
                    {
                        ToolTip = ResourceManager.LocalizationResource.GoToLast,
                        Image = ResourceManager.ImagesResource.DataContainerMoveLastHs,
                        Command = /* ToDo: Add GoToLast command */ null
                    },
                    new SeparatorToolItem(),
                    new ButtonToolItem  //PlayPause
                    {
                        ToolTip = ResourceManager.LocalizationResource.PlayPause,
                        Image = ResourceManager.ImagesResource.PlayHs,
                        Command = /* ToDo: Add PlayPause command */ null
                    },
                    new ButtonToolItem  //Repeat
                    {
                        ToolTip = ResourceManager.LocalizationResource.Repeat,
                        Image = ResourceManager.ImagesResource.RepeatHs,
                        Command = /* ToDo: Add Repeat command */ null
                    },
                    new SeparatorToolItem(),
                    new ButtonToolItem  //RecordNew
                    {
                        Text = ResourceManager.LocalizationResource.RecordNewPosition,
                        ToolTip = ResourceManager.LocalizationResource.RecordNewPosition,
                        Image = ResourceManager.ImagesResource.RecordHs,
                        Command = /* ToDo: Add RecordNewPosition command */ null
                    },
                    new ButtonToolItem  //RecordOverCurrent
                    {
                        Text = ResourceManager.LocalizationResource.RecordOverCurrentPosition,
                        ToolTip = ResourceManager.LocalizationResource.RecordOverCurrentPosition,
                        Command = /* ToDo: Add RecordOverCurrentPosition command */ null
                    },
                    new ButtonToolItem  //RemoveCurrent
                    {
                        Text = ResourceManager.LocalizationResource.RemoveCurrent,
                        ToolTip = ResourceManager.LocalizationResource.RemoveCurrent,
                        Image = ResourceManager.ImagesResource.DeleteHs,
                        Command = /* ToDo: Add RemoveCurrent command */ null
                    },
                    new ButtonToolItem  //RevertCurrent
                    {
                        Text = ResourceManager.LocalizationResource.RevertCurrent,
                        ToolTip = ResourceManager.LocalizationResource.RevertCurrent,
                        Image = ResourceManager.ImagesResource.EditUndoHs,
                        Command = /* ToDo: Add RevertCurrent command */ null
                    },
                    new SeparatorToolItem(),
                    new CheckToolItem   //ShowMovement
                    {
                        Text = ResourceManager.LocalizationResource.ShowMovement,
                        ToolTip = ResourceManager.LocalizationResource.ShowMovement,
                        Command = /* ToDo: Add ShowMovement command */ null
                    },
                    new SeparatorToolItem()
                }
            };
            ToolBar = toolbar;
        }
    }
}
