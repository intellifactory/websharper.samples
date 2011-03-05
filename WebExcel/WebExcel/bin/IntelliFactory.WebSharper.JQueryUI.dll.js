(function()
{
  var global = this;
  var Accordion, Attr, Autocomplete, AutocompleteConfiguration, Button, Class,
      Datepicker, DatepickerConfiguration, Dialog, Draggable, Droppable,
      FSharpList_1, Html, Html_1, JQueryUI, Map, New1, New1_1, New1_2, New2,
      New3, NewUnion, OfArray, OfSeq, OnAfterRender, OnBeforeRender, Pagelet,
      Position, Progressbar, ProgressbarConfiguration, Resizable, Selectable,
      SeqModule, Slider, Sortable, Tabs, Test, Tupled, Utils, __11, __2, __28,
      __3, log, op_MinusLess, random, round;
  IntelliFactory.WebSharper.Runtime.Declare({IntelliFactory:
                                             {WebSharper:
                                              {JQueryUI:
                                               {
                                                 Utils:
                                                   {Pagelet: {}},
                                                 Test:
                                                   {},
                                                 Target:
                                                   {},
                                                 TabsFxConfiguration:
                                                   {},
                                                 TabsCookieConfiguration:
                                                   {},
                                                 TabsConfiguration:
                                                   {},
                                                 TabsAjaxOptionsConfiguration:
                                                   {},
                                                 Tabs:
                                                   {},
                                                 SortableConfiguration:
                                                   {},
                                                 Sortable:
                                                   {},
                                                 SliderConfiguration:
                                                   {},
                                                 Slider:
                                                   {},
                                                 SelectableConfiguration:
                                                   {},
                                                 Selectable:
                                                   {},
                                                 ResizableConfiguration:
                                                   {},
                                                 Resizable:
                                                   {},
                                                 ProgressbarConfiguration:
                                                   {},
                                                 Progressbar:
                                                   {},
                                                 PositionConfiguration:
                                                   {},
                                                 Position:
                                                   {},
                                                 DroppableConfiguration:
                                                   {},
                                                 Droppable:
                                                   {},
                                                 DraggablecursorAtConfiguration:
                                                   {},
                                                 DraggableStackConfiguration:
                                                   {},
                                                 DraggableConfiguration:
                                                   {},
                                                 Draggable:
                                                   {},
                                                 DialogConfiguration:
                                                   {},
                                                 Dialog:
                                                   {},
                                                 DatepickerShowOptionsConfiguration:
                                                   {},
                                                 DatepickerConfiguration:
                                                   {},
                                                 Datepicker:
                                                   {},
                                                 ButtonIconsConfiguration:
                                                   {},
                                                 ButtonConfiguration:
                                                   {},
                                                 Button:
                                                   {},
                                                 AutocompleteConfiguration:
                                                   {},
                                                 Autocomplete:
                                                   {},
                                                 AccordionIconConfiguration:
                                                   {},
                                                 AccordionConfiguration:
                                                   {},
                                                 Accordion:
                                                   {}
                                               }}}});
  Utils = function()
          {
            return IntelliFactory.WebSharper.JQueryUI.Utils;
          };
  JQueryUI = function()
             {
               return IntelliFactory.WebSharper.JQueryUI;
             };
  (function()
   {
     return IntelliFactory.WebSharper;
   });
  Class = function()
          {
            return IntelliFactory.WebSharper.Runtime.Class;
          };
  (function()
   {
     return IntelliFactory.WebSharper.Runtime;
   });
  __2 = function()
        {
          var _this = this;
          var _, __1, c, matchValue;
          matchValue = {$: 0};
          if (matchValue.$ == 1)
          {
            c = matchValue.$0;
            _ = [];
            __1 = void c.apply(_this, _);
          }
          __1;
        };
  __3 =
  function()
  {
    var _this = this;
    var _, __1, c, matchValue;
    matchValue = {$: 1, $0: IntelliFactory.WebSharper.JQueryUI.Utils.Pagelet};
    if (matchValue.$ == 1)
    {
      c = matchValue.$0;
      _ = [];
      __1 = void c.apply(_this, _);
    }
    __1;
  };
  Pagelet = function()
            {
              return IntelliFactory.WebSharper.JQueryUI.Utils.Pagelet;
            };
  OnAfterRender =
  function()
  {
    return IntelliFactory.WebSharper.Html.Operators.OnAfterRender;
  };
  (function()
   {
     return IntelliFactory.WebSharper.Html.Operators;
   });
  Html_1 = function()
           {
             return IntelliFactory.WebSharper.Html;
           };
  round = function()
          {
            return Math.round;
          };
  random = function()
           {
             return Math.random;
           };
  op_MinusLess = function()
                 {
                   return IntelliFactory.WebSharper.Html.Operators.op_MinusLess;
                 };
  OfArray = function()
            {
              return IntelliFactory.WebSharper.Core.ListModule.OfArray;
            };
  (function()
   {
     return IntelliFactory.WebSharper.Core.ListModule;
   });
  (function()
   {
     return IntelliFactory.WebSharper.Core;
   });
  Attr = function()
         {
           return IntelliFactory.WebSharper.Html.Implementation.Attr;
         };
  (function()
   {
     return IntelliFactory.WebSharper.Html.Implementation;
   });
  Html = function()
         {
           return IntelliFactory.WebSharper.Html.Implementation.Html;
         };
  OnBeforeRender =
  function()
  {
    return IntelliFactory.WebSharper.Html.Operators.OnBeforeRender;
  };
  __11 = function(value)
         {
           return void value;
         };
  log = function()
        {
          return console.log;
        };
  Position = function()
             {
               return IntelliFactory.WebSharper.JQueryUI.Position;
             };
  Sortable = function()
             {
               return IntelliFactory.WebSharper.JQueryUI.Sortable;
             };
  Selectable = function()
               {
                 return IntelliFactory.WebSharper.JQueryUI.Selectable;
               };
  Resizable = function()
              {
                return IntelliFactory.WebSharper.JQueryUI.Resizable;
              };
  Droppable = function()
              {
                return IntelliFactory.WebSharper.JQueryUI.Droppable;
              };
  Draggable = function()
              {
                return IntelliFactory.WebSharper.JQueryUI.Draggable;
              };
  Tabs = function()
         {
           return IntelliFactory.WebSharper.JQueryUI.Tabs;
         };
  OfSeq = function()
          {
            return IntelliFactory.WebSharper.Core.ListModule.OfSeq;
          };
  Map = function()
        {
          return IntelliFactory.WebSharper.Core.SeqModule.Map;
        };
  SeqModule = function()
              {
                return IntelliFactory.WebSharper.Core.SeqModule;
              };
  Tupled = function()
           {
             return IntelliFactory.WebSharper.Runtime.Tupled;
           };
  Slider = function()
           {
             return IntelliFactory.WebSharper.JQueryUI.Slider;
           };
  NewUnion = function()
             {
               return IntelliFactory.WebSharper.Runtime.NewUnion;
             };
  FSharpList_1 = function()
                 {
                   return IntelliFactory.WebSharper.Core["FSharpList`1"];
                 };
  Progressbar = function()
                {
                  return IntelliFactory.WebSharper.JQueryUI.Progressbar;
                };
  New1 = function()
         {
           return IntelliFactory.WebSharper.JQueryUI.Progressbar.New1;
         };
  ProgressbarConfiguration =
  function()
  {
    return IntelliFactory.WebSharper.JQueryUI.ProgressbarConfiguration;
  };
  Dialog = function()
           {
             return IntelliFactory.WebSharper.JQueryUI.Dialog;
           };
  Datepicker = function()
               {
                 return IntelliFactory.WebSharper.JQueryUI.Datepicker;
               };
  New1_1 = function()
           {
             return IntelliFactory.WebSharper.JQueryUI.Datepicker.New1;
           };
  DatepickerConfiguration =
  function()
  {
    return IntelliFactory.WebSharper.JQueryUI.DatepickerConfiguration;
  };
  Button = function()
           {
             return IntelliFactory.WebSharper.JQueryUI.Button;
           };
  Autocomplete = function()
                 {
                   return IntelliFactory.WebSharper.JQueryUI.Autocomplete;
                 };
  New1_2 = function()
           {
             return IntelliFactory.WebSharper.JQueryUI.Autocomplete.New1;
           };
  AutocompleteConfiguration =
  function()
  {
    return IntelliFactory.WebSharper.JQueryUI.AutocompleteConfiguration;
  };
  Accordion = function()
              {
                return IntelliFactory.WebSharper.JQueryUI.Accordion;
              };
  Test = function()
         {
           return IntelliFactory.WebSharper.JQueryUI.Test;
         };
  New2 = function()
         {
           return IntelliFactory.WebSharper.JQueryUI.Accordion.New2;
         };
  New3 = function()
         {
           return IntelliFactory.WebSharper.JQueryUI.Button.New3;
         };
  __28 =
  function(w)
  {
    return IntelliFactory.WebSharper.Html.Operators.OnBeforeRender(function()
                                                                   {
                                                                     var _;
                                                                     _ = console;
                                                                     return console.log.call(_,
                                                                                             "Before Render");
                                                                   }, w);
  };
  (function()
   {
     var _;
     _ = console;
     return console.log.call(_, "Before Render");
   });
  Utils().Pagelet = Class()(__2, null, {
                                         Render:
                                           function()
                                           {
                                             var _this = this;
                                             var _;
                                             _ = _this.element;
                                             return _.Render();
                                           },
                                         get_Body:
                                           function()
                                           {
                                             var _this = this;
                                             return _this.element.Body;
                                           }
                                       });
  JQueryUI().Position = Class()(__3, Pagelet(), {});
  JQueryUI().PositionConfiguration =
  Class()(__2, null, {
                       get_Of:
                         function()
                         {
                           var _this = this;
                           return _this.ofTarget;
                         },
                       set_Of:
                         function(t)
                         {
                           var _this = this;
                           _this.ofTarget = t;
                           return _this.of = t.toString();
                         },
                       get_Offset:
                         function()
                         {
                           var _this = this;
                           return _this.offsetTuple;
                         },
                       set_Offset:
                         function(pos)
                         {
                           var _this = this;
                           var _, x, y;
                           _this.offsetTuple = pos;
                           y = pos[1];
                           x = pos[0];
                           _ = x.toString() + " ";
                           return _this.offset = _ + y.toString();
                         }
                     });
  JQueryUI().Target = Class()(null, null, {
                                            ToString:
                                              function()
                                              {
                                                var _this = this;
                                                var _, __1;
                                                if (_this.$ == 1)
                                                __1 = _this.$0;
                                                else
                                                {
                                                  if (_this.$ == 2)
                                                  _ = "#" + _this.$0;
                                                  else
                                                  _ = _this.$0;
                                                  __1 = _;
                                                }
                                                return __1;
                                              }
                                          });
  JQueryUI().Sortable =
  Class()(__3, Pagelet(),
          {
            OnStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               sort:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.start);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnSort:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               sort:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.sort);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnChange:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               change:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.change);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnBeforeStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               beforeStop:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.beforeStop);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               stop:
                                                                 function
                                                                 (event, ui)
                                                                 {
                                                                   return f(event)(ui);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnUpdate:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               update:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.update);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnReceive:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               receive:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.receive);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnRemove:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               remove:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.remove);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnOver:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               out:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.out);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnActivate:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               activate:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.activate);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              },
            OnDeactivate:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.sortable({
                                                               deactivate:
                                                                 function(x, y)
                                                                 {
                                                                   return f(x)(y.deactivate);
                                                                 }
                                                             });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().SortableConfiguration = Class()(__2, null, {});
  JQueryUI().Selectable =
  Class()(__3, Pagelet(),
          {
            OnSelected:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.selectable({
                                                                 selected:
                                                                   function
                                                                   (x, y)
                                                                   {
                                                                     return f(x)(y.selected);
                                                                   }
                                                               });
                                         }, w);
                };
                return __1(_this);
              },
            OnSelecting:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.selectable({
                                                                 selecting:
                                                                   function
                                                                   (x, y)
                                                                   {
                                                                     return f(x)(y.selecting);
                                                                   }
                                                               });
                                         }, w);
                };
                return __1(_this);
              },
            OnStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.selectable({
                                                                 start:
                                                                   function
                                                                   (x, y)
                                                                   {
                                                                     return f(x)(y.start);
                                                                   }
                                                               });
                                         }, w);
                };
                return __1(_this);
              },
            OnStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.selectable({
                                                                 stop:
                                                                   function
                                                                   (x, y)
                                                                   {
                                                                     return f(x)(y.stop);
                                                                   }
                                                               });
                                         }, w);
                };
                return __1(_this);
              },
            OnUnselected:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.selectable({
                                                                 unselected:
                                                                   function
                                                                   (x, y)
                                                                   {
                                                                     return f(x)(y.unselected);
                                                                   }
                                                               });
                                         }, w);
                };
                return __1(_this);
              },
            OnUnselecting:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.selectable({
                                                                 unselecting:
                                                                   function
                                                                   (x, y)
                                                                   {
                                                                     return f(x)(y.unselecting);
                                                                   }
                                                               });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().SelectableConfiguration = Class()(__2, null, {});
  JQueryUI().Resizable =
  Class()(__3, Pagelet(),
          {
            OnStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.resizable({
                                                                start:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.start);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnResize:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.resizable({
                                                                resize:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.resize);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.resizable({
                                                                stop:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.stop);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().ResizableConfiguration = Class()(__2, null, {});
  JQueryUI().Droppable =
  Class()(__3, Pagelet(),
          {
            OnActivate:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.droppable({
                                                                activate:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.activate);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnDeactivate:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.droppable({
                                                                deactivate:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.deactivate);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnOver:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.droppable({
                                                                over:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.over);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnOut:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.droppable({
                                                                out:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.out);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnDrop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.droppable({
                                                                drop:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.drop);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().DroppableConfiguration = Class()(__2, null, {});
  JQueryUI().Draggable =
  Class()(__3, Pagelet(),
          {
            OnStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.draggable({
                                                                start:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.start);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.draggable({
                                                                stop:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.stop);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnDrag:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.draggable({
                                                                drag:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.drag);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().DraggableConfiguration = Class()(__2, null, {});
  JQueryUI().Tabs =
  Class()(__3, Pagelet(),
          {
            get_Length:
              function()
              {
                var _this = this;
                var _;
                _ = jQuery(_this.element.Body);
                return _.tabs("length");
              },
            Add:
              function(el, label, ix)
              {
                var _this = this;
                var _, __1, __4, __5, __6, __7, __8, __9, id, tab;
                _ = Math;
                __1 = Math;
                id = "id" + round().call(_, random().call(__1) * 100000000);
                __4 = Attr();
                __6 = OfArray()([__4.NewAttr("id", id)]);
                __5 = Html();
                tab = op_MinusLess()(__5.Div(__6), OfArray()([el]));
                __7 = _this.element;
                __7.AppendI(tab);
                __9 = "#" + id;
                __8 = jQuery(_this.element.Body);
                return __8.tabs("add", __9, label, ix);
              },
            Add1:
              function(el, label)
              {
                var _this = this;
                var _, __1, __10, __4, __5, __6, __7, __8, __9, id, tab;
                _ = Math;
                __1 = Math;
                id = "id" + round().call(_, random().call(__1) * 100000000);
                __4 = Attr();
                __6 = OfArray()([__4.NewAttr("id", id)]);
                __5 = Html();
                tab = op_MinusLess()(__5.Div(__6), OfArray()([el]));
                __7 = _this.element;
                __7.AppendI(tab);
                __9 = "#" + id;
                __10 = _this.get_Length();
                __8 = jQuery(_this.element.Body);
                return __8.tabs("add", __9, label, __10);
              },
            OnSelect:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.tabs({
                                                           select:
                                                             function(x)
                                                             {
                                                               return f(x);
                                                             }
                                                         });
                                         }, w);
                };
                return __1(_this);
              },
            OnLoad:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.tabs({
                                                           load:
                                                             function(x)
                                                             {
                                                               return f(x);
                                                             }
                                                         });
                                         }, w);
                };
                return __1(_this);
              },
            OnShow:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.tabs({
                                                           show:
                                                             function(x)
                                                             {
                                                               return f(x);
                                                             }
                                                         });
                                         }, w);
                };
                return __1(_this);
              },
            OnAdd:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.tabs({
                                                           add:
                                                             function(x)
                                                             {
                                                               return f(x);
                                                             }
                                                         });
                                         }, w);
                };
                return __1(_this);
              },
            OnEnable:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.tabs({
                                                           enable:
                                                             function(x)
                                                             {
                                                               return f(x);
                                                             }
                                                         });
                                         }, w);
                };
                return __1(_this);
              },
            OnDisable:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.tabs({
                                                           diable:
                                                             function(x)
                                                             {
                                                               return f(x);
                                                             }
                                                         });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().TabsConfiguration = Class()(__2, null, {});
  JQueryUI().Slider =
  Class()(__3, Pagelet(),
          {
            set_Value:
              function(v)
              {
                var _this = this;
                var _;
                _ = jQuery(_this.element.Body);
                return _.slider("value", v);
              },
            get_Value:
              function()
              {
                var _this = this;
                var _;
                _ = jQuery(_this.element.Body);
                return _.slider("value");
              },
            OnStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.slider({
                                                             start:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnChange:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.slider({
                                                             change:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnSlide:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.slider({
                                                             slide:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.slider({
                                                             stop:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().SliderConfiguration = Class()(__2, null, {});
  JQueryUI().Progressbar =
  Class()(__3, Pagelet(),
          {
            get_Value:
              function()
              {
                var _this = this;
                var _;
                _ = jQuery(_this.element.Body);
                return _.progressbar("value");
              },
            set_Value:
              function(v)
              {
                var _this = this;
                var _;
                _ = jQuery(_this.element.Body);
                return _.progressbar("value", v);
              },
            OnChange:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.accordion({
                                                                change:
                                                                  function(x)
                                                                  {
                                                                    return f(x);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().ProgressbarConfiguration = Class()(__2, null, {});
  JQueryUI().Dialog =
  Class()(__3, Pagelet(),
          {
            OnBeforeClose:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             beforeclose:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnOpen:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             open:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnFocus:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             focus:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnDragStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             dragStart:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnDrag:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             drag:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnDragStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             dragStop:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnResizeStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             resizeStart:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnResize:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             resize:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnResizeStop:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             resizeStop:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              },
            OnClose:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.dialog({
                                                             close:
                                                               function(x)
                                                               {
                                                                 return f(x);
                                                               }
                                                           });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().DialogConfiguration = Class()(__2, null, {});
  JQueryUI().Datepicker =
  Class()(__3, Pagelet(),
          {
            OnSelect:
              function(f)
              {
                var _this = this;
                var __5, __6;
                __5 =
                function(w)
                {
                  return OnBeforeRender()(function()
                                          {
                                            var __1, __4;
                                            __1 =
                                            function(arg00)
                                            {
                                              var _;
                                              _ = jQuery(_this.element.Body);
                                              return _.datepicker({
                                                                    onSelect:
                                                                      function
                                                                      (x)
                                                                      {
                                                                        return arg00(x);
                                                                      }
                                                                  });
                                            };
                                            __4 = function(s)
                                                  {
                                                    var _;
                                                    _ = new Date(s);
                                                    return f(_);
                                                  };
                                            return __1(__4);
                                          }, w);
                };
                __6 = __5(_this);
                return __11(__6);
              },
            OnClose:
              function(f)
              {
                var _this = this;
                var __1, __4;
                __1 =
                function(w)
                {
                  return OnBeforeRender()(function()
                                          {
                                            var _;
                                            _ = jQuery(_this.element.Body);
                                            return _.datepicker({
                                                                  onClose:
                                                                    function()
                                                                    {
                                                                      return f();
                                                                    }
                                                                });
                                          }, w);
                };
                __4 = __1(_this);
                return __11(__4);
              }
          });
  JQueryUI().DatepickerConfiguration = Class()(__2, null, {});
  JQueryUI().Button =
  Class()(__3, Pagelet(),
          {
            get_IsEnabled:
              function()
              {
                var _this = this;
                return _this.isEnabled;
              },
            Disable:
              function()
              {
                var _this = this;
                var _;
                _this.isEnabled = false;
                _ = jQuery(_this.element.Body);
                return _.button("disable");
              },
            Enable:
              function()
              {
                var _this = this;
                var _;
                _this.isEnabled = true;
                _ = jQuery(_this.element.Body);
                return _.button("enable");
              },
            OnClick:
              function(f)
              {
                var _this = this;
                var __4, __5;
                __5 = _this.element;
                __4 = function(arg10)
                      {
                        var _;
                        _ = Html_1().EventsPervasives.Events;
                        return _.OnClick(function()
                                         {
                                           return function(ev)
                                                  {
                                                    var __1;
                                                    if (_this.isEnabled)
                                                    __1 = f(ev);
                                                    return __1;
                                                  };
                                         }, arg10);
                      };
                return __4(__5);
              }
          });
  JQueryUI().ButtonConfiguration = Class()(__2, null, {});
  JQueryUI().Autocomplete =
  Class()(__2, null,
          {
            get_Body:
              function()
              {
                var _this = this;
                var _;
                _ = _this.element;
                return _.get_Body();
              },
            Render:
              function()
              {
                var _this = this;
                var _, __1;
                _ = console;
                log().call(_, "Render auto complete");
                __1 = _this.element;
                return __1.Render();
              },
            OnSelect:
              function(f)
              {
                var _this = this;
                var __1, __4;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.autocomplete({
                                                                   select:
                                                                     function
                                                                     (x, y)
                                                                     {
                                                                       return f(x)(y.select);
                                                                     }
                                                                 });
                                         }, w);
                };
                __4 = __1(_this);
                return __11(__4);
              },
            OnFocus:
              function(f)
              {
                var _this = this;
                var __1, __4;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.autocomplete({
                                                                   focus:
                                                                     function
                                                                     (x, y)
                                                                     {
                                                                       return f(x)(y.focus);
                                                                     }
                                                                 });
                                         }, w);
                };
                __4 = __1(_this);
                return __11(__4);
              },
            OnClose:
              function(f)
              {
                var _this = this;
                var __1, __4;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.autocomplete({
                                                                   close:
                                                                     function
                                                                     (x, y)
                                                                     {
                                                                       return f(x)(y.close);
                                                                     }
                                                                 });
                                         }, w);
                };
                __4 = __1(_this);
                return __11(__4);
              },
            OnChange:
              function(f)
              {
                var _this = this;
                var __1, __4;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.autocomplete({
                                                                   change:
                                                                     function
                                                                     (x, y)
                                                                     {
                                                                       return f(x)(y.change);
                                                                     }
                                                                 });
                                         }, w);
                };
                __4 = __1(_this);
                return __11(__4);
              },
            OnSearch:
              function(f)
              {
                var _this = this;
                var __1, __4;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.autocomplete({
                                                                   search:
                                                                     function
                                                                     (x, y)
                                                                     {
                                                                       return f(x)(y.search);
                                                                     }
                                                                 });
                                         }, w);
                };
                __4 = __1(_this);
                return __11(__4);
              }
          });
  JQueryUI().AutocompleteConfiguration = Class()(__2, null, {});
  JQueryUI().Accordion =
  Class()(__3, Pagelet(),
          {
            OnChange:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.accordion({
                                                                change:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.change);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              },
            OnChangeStart:
              function(f)
              {
                var _this = this;
                var __1;
                __1 =
                function(w)
                {
                  return OnAfterRender()(function()
                                         {
                                           var _;
                                           _ = jQuery(_this.element.Body);
                                           return _.accordion({
                                                                change:
                                                                  function(x, y)
                                                                  {
                                                                    return f(x)(y.changestart);
                                                                  }
                                                              });
                                         }, w);
                };
                return __1(_this);
              }
          });
  JQueryUI().AccordionConfiguration = Class()(__2, null, {});
  Position().New1 =
  function(el_1, conf)
  {
    var __4, a;
    a = new (Position())();
    __4 = function(w)
          {
            return OnAfterRender()(function(el)
                                   {
                                     var _, __1;
                                     _ = el.Body;
                                     __1 = jQuery(_);
                                     return __1.position(conf);
                                   }, w);
          };
    __4(el_1);
    a.element = el_1;
    return a;
  };
  Position().New2 = function(el)
                    {
                      var conf;
                      conf = new (JQueryUI().PositionConfiguration)();
                      return Position().New1(el, conf);
                    };
  Sortable().New1 =
  function(el_1, conf)
  {
    var __4, s;
    s = new (Sortable())();
    __4 = function(w)
          {
            return OnAfterRender()(function(el)
                                   {
                                     var _, __1;
                                     _ = el.Body;
                                     __1 = jQuery(_);
                                     return __1.sortable(conf);
                                   }, w);
          };
    __4(el_1);
    s.element = el_1;
    return s;
  };
  Sortable().New2 = function(el)
                    {
                      var conf;
                      conf = new (JQueryUI().SortableConfiguration)();
                      return Sortable().New1(el, conf);
                    };
  Selectable().New1 =
  function(el_1, conf)
  {
    var __4, a;
    a = new (Selectable())();
    __4 = function(w)
          {
            return OnAfterRender()(function(el)
                                   {
                                     var _, __1;
                                     _ = el.Body;
                                     __1 = jQuery(_);
                                     return __1.selectable(conf);
                                   }, w);
          };
    __4(el_1);
    a.element = el_1;
    return a;
  };
  Selectable().New2 = function(el)
                      {
                        var conf;
                        conf = new (JQueryUI().SelectableConfiguration)();
                        return Selectable().New1(el, conf);
                      };
  Resizable().New1 =
  function(el_1, conf)
  {
    var __4, a;
    a = new (Resizable())();
    __4 = function(w)
          {
            return OnAfterRender()(function(el)
                                   {
                                     var _, __1;
                                     _ = el.Body;
                                     __1 = jQuery(_);
                                     return __1.resizable(conf);
                                   }, w);
          };
    __4(el_1);
    a.element = el_1;
    return a;
  };
  Resizable().New2 = function(el)
                     {
                       var conf;
                       conf = new (JQueryUI().ResizableConfiguration)();
                       return Resizable().New1(el, conf);
                     };
  Droppable().New1 =
  function(el_1, conf)
  {
    var __4, a;
    a = new (Droppable())();
    __4 = function(w)
          {
            return OnAfterRender()(function(el)
                                   {
                                     var _, __1;
                                     _ = el.Body;
                                     __1 = jQuery(_);
                                     return __1.droppable(conf);
                                   }, w);
          };
    __4(el_1);
    a.element = el_1;
    return a;
  };
  Droppable().New2 = function(el)
                     {
                       var conf;
                       conf = new (JQueryUI().DroppableConfiguration)();
                       return Droppable().New1(el, conf);
                     };
  Draggable().New1 =
  function(el_1, conf)
  {
    var __4, a;
    a = new (Draggable())();
    __4 = function(w)
          {
            return OnAfterRender()(function(el)
                                   {
                                     var _, __1;
                                     _ = el.Body;
                                     __1 = jQuery(_);
                                     return __1.draggable(conf);
                                   }, w);
          };
    __4(el_1);
    a.element = el_1;
    return a;
  };
  Draggable().New2 = function(el)
                     {
                       var conf;
                       conf = new (JQueryUI().DraggableConfiguration)();
                       return Draggable().New1(el, conf);
                     };
  JQueryUI().DraggableStackConfiguration.get_Default =
  function()
  {
    return {group: "prouducts", min: 50};
  };
  JQueryUI().DraggablecursorAtConfiguration.get_Default =
  function()
  {
    return {top: 1, left: 1};
  };
  Tabs().New1 =
  function(els, conf)
  {
    var __15, __16, __17, __18, __19, __20, __21, el_1, itemPanels, tabs, ul;
    __15 =
    function(list)
    {
      return OfSeq()(Map()(Tupled()(function(tupledArg)
                                    {
                                      var _, __1, __10, __12, __13, __14, __4,
                                          __5, __6, __7, __8, __9, id, item,
                                          label, panel, tab;
                                      label = tupledArg[0];
                                      panel = tupledArg[1];
                                      _ = Math;
                                      __1 = Math;
                                      id =
                                      "id" +
                                      round().call(_,
                                                   random().call(__1) *
                                                   100000000);
                                      __4 = Attr();
                                      __5 = "#" + id;
                                      __6 = Html();
                                      __8 =
                                      OfArray()([__4.NewAttr("href", __5),
                                                 __6.text(label)]);
                                      __7 = Html();
                                      __10 =
                                      OfArray()([__7.NewTag("a", __8), panel]);
                                      __9 = Html();
                                      item = __9.NewTag("li", __10);
                                      __12 = Attr();
                                      __14 = OfArray()([__12.NewAttr("id", id)]);
                                      __13 = Html();
                                      tab =
                                      op_MinusLess()(__13.Div(__14),
                                                     OfArray()([panel]));
                                      return [item, tab];
                                    }), list));
    };
    itemPanels = __15(els);
    __16 = function(x)
           {
             var _;
             _ = Html();
             return _.NewTag("ul", x);
           };
    __17 = Map()(Tupled()(function(tuple)
                          {
                            return tuple[0];
                          }), itemPanels);
    ul = __16(__17);
    __19 = OfArray()([ul]);
    __18 = Html();
    __20 = Tupled()(function(tuple)
                    {
                      return tuple[1];
                    });
    el_1 = op_MinusLess()(__18.Div(__19), OfSeq()(Map()(__20, itemPanels)));
    tabs = new (Tabs())();
    __21 = function(w)
           {
             return OnAfterRender()(function(el)
                                    {
                                      var _, __1;
                                      _ = el.Body;
                                      __1 = jQuery(_);
                                      return __1.tabs(conf);
                                    }, w);
           };
    __21(el_1);
    tabs.element = el_1;
    return tabs;
  };
  Tabs().New2 = function(els)
                {
                  return Tabs().New1(els, new (JQueryUI().TabsConfiguration)());
                };
  JQueryUI().TabsFxConfiguration.get_Dafault = function()
                                               {
                                                 return {fx: "toggle"};
                                               };
  JQueryUI().TabsCookieConfiguration.get_Default = function()
                                                   {
                                                     return {cookie: 30};
                                                   };
  JQueryUI().TabsAjaxOptionsConfiguration.get_Default =
  function()
  {
    return {ajaxOptions: false};
  };
  Slider().New1 = function(conf)
                  {
                    var _, __1, __6, __7, s;
                    s = new (Slider())();
                    __1 = NewUnion()(FSharpList_1(), 0);
                    _ = Html();
                    __7 = _.Div(__1);
                    __6 = function(w)
                          {
                            return OnAfterRender()(function(el)
                                                   {
                                                     var __4, __5;
                                                     __4 = el.Body;
                                                     __5 = jQuery(__4);
                                                     return __5.slider(conf);
                                                   }, w);
                          };
                    __6(__7);
                    s.element = __7;
                    return s;
                  };
  Slider().New2 =
  function()
  {
    return Slider().New1(new (JQueryUI().SliderConfiguration)());
  };
  Progressbar().New1 =
  function(el, conf)
  {
    var __4, pb;
    pb = new (Progressbar())();
    pb.element = el;
    __4 = function(w)
          {
            return OnAfterRender()(function(el_1)
                                   {
                                     var _, __1;
                                     _ = el_1.Body;
                                     __1 = jQuery(_);
                                     return __1.progressbar(conf);
                                   }, w);
          };
    __4(el);
    return pb;
  };
  Progressbar().New2 = function(el)
                       {
                         return New1()(el, new (ProgressbarConfiguration())());
                       };
  Progressbar().New3 = function(conf)
                       {
                         var _, __1;
                         __1 = NewUnion()(FSharpList_1(), 0);
                         _ = Html();
                         return New1()(_.Div(__1), conf);
                       };
  Progressbar().New4 =
  function()
  {
    var _, __1;
    __1 = NewUnion()(FSharpList_1(), 0);
    _ = Html();
    return New1()(_.Div(__1), new (ProgressbarConfiguration())());
  };
  Dialog().New1 = function(el_1, conf)
                  {
                    var __4, d;
                    d = new (Dialog())();
                    __4 = function(w)
                          {
                            return OnAfterRender()(function(el)
                                                   {
                                                     var _, __1;
                                                     _ = el.Body;
                                                     __1 = jQuery(_);
                                                     return __1.dialog(conf);
                                                   }, w);
                          };
                    __4(el_1);
                    d.element = el_1;
                    return d;
                  };
  Dialog().New2 =
  function(el)
  {
    return Dialog().New1(el, new (JQueryUI().DialogConfiguration)());
  };
  Datepicker().New1 =
  function(el, conf)
  {
    var __4, __5, dp;
    dp = new (Datepicker())();
    dp.element = el;
    __4 = function(w)
          {
            return OnAfterRender()(function(el_1)
                                   {
                                     var _, __1;
                                     _ = el_1.Body;
                                     __1 = jQuery(_);
                                     return __1.datepicker(conf);
                                   }, w);
          };
    __5 = __4(el);
    __11(__5);
    return dp;
  };
  Datepicker().New2 = function(el)
                      {
                        return New1_1()(el, new (DatepickerConfiguration())());
                      };
  Datepicker().New3 = function(conf)
                      {
                        var _, __1;
                        __1 = NewUnion()(FSharpList_1(), 0);
                        _ = Html();
                        return New1_1()(_.Div(__1), conf);
                      };
  Datepicker().New4 =
  function()
  {
    var _, __1;
    __1 = NewUnion()(FSharpList_1(), 0);
    _ = Html();
    return New1_1()(_.Div(__1), new (DatepickerConfiguration())());
  };
  JQueryUI().DatepickerShowOptionsConfiguration.get_Default =
  function()
  {
    return {showOptions: "up"};
  };
  Button().New1 = function(el_1, conf)
                  {
                    var __4, __5, b;
                    b = new (Button())();
                    b.isEnabled = true;
                    __4 = function(w)
                          {
                            return OnAfterRender()(function(el)
                                                   {
                                                     var _, __1;
                                                     _ = el.Body;
                                                     __1 = jQuery(_);
                                                     return __1.button(conf);
                                                   }, w);
                          };
                    __5 = __4(el_1);
                    __11(__5);
                    b.element = el_1;
                    return b;
                  };
  Button().New2 = function(conf)
                  {
                    var _, __1;
                    __1 = NewUnion()(FSharpList_1(), 0);
                    _ = Html();
                    return Button().New1(_.NewTag("button", __1), conf);
                  };
  Button().New3 = function(label)
                  {
                    var conf;
                    conf = new (JQueryUI().ButtonConfiguration)();
                    conf.label = label;
                    return Button().New2(conf);
                  };
  JQueryUI().ButtonIconsConfiguration.get_Default =
  function()
  {
    return {primary: "ui-icon-gear", Secondary: "ui-icon-triangle-1-s"};
  };
  Autocomplete().New1 =
  function(el_1, conf)
  {
    var __5, a;
    a = new (Autocomplete())();
    __5 = function(w)
          {
            return OnAfterRender()(function(el)
                                   {
                                     var _, __1, __4;
                                     _ = console;
                                     log().call(_, "Init autocomplete");
                                     __1 = el.Body;
                                     __4 = jQuery(__1);
                                     return __4.autocomplete(conf);
                                   }, w);
          };
    __5(el_1);
    a.element = el_1;
    return a;
  };
  Autocomplete().New2 =
  function(el)
  {
    return New1_2()(el, new (AutocompleteConfiguration())());
  };
  Autocomplete().New3 =
  function()
  {
    var _, __1;
    __1 = NewUnion()(FSharpList_1(), 0);
    _ = Html();
    return New1_2()(_.NewTag("input", __1), new (AutocompleteConfiguration())());
  };
  Autocomplete().New4 = function(conf)
                        {
                          var _, __1;
                          __1 = NewUnion()(FSharpList_1(), 0);
                          _ = Html();
                          return New1_2()(_.NewTag("input", __1), conf);
                        };
  Accordion().New1 =
  function(els, conf)
  {
    var __10, __12, __13, __14, __15, __16, a, els_1, panel;
    a = new (Accordion())();
    __10 =
    function(list)
    {
      return OfSeq()(Map()(Tupled()(function(tupledArg)
                                    {
                                      var _, __1, __4, __5, __6, __7, __8, __9,
                                          el, header;
                                      header = tupledArg[0];
                                      el = tupledArg[1];
                                      _ = Attr();
                                      __1 = Html();
                                      __5 =
                                      OfArray()([_.NewAttr("href", "#"),
                                                 __1.text(header)]);
                                      __4 = Html();
                                      __7 = OfArray()([__4.NewTag("a", __5)]);
                                      __6 = Html();
                                      __9 = OfArray()([el]);
                                      __8 = Html();
                                      return OfArray()([__6.NewTag("h3", __7),
                                                        __8.Div(__9)]);
                                    }), list));
    };
    __13 = __10(els);
    __12 = function(lists)
           {
             return OfSeq()(SeqModule().Concat(lists));
           };
    els_1 = __12(__13);
    __14 = Html();
    __16 = __14.Div(els_1);
    __15 = function(w)
           {
             return OnAfterRender()(function(el)
                                    {
                                      var _, __1;
                                      _ = el.Body;
                                      __1 = jQuery(_);
                                      return __1.accordion(conf);
                                    }, w);
           };
    __15(__16);
    panel = __16;
    a.element = panel;
    return a;
  };
  Accordion().New2 =
  function(els)
  {
    return Accordion().New1(els, new (JQueryUI().AccordionConfiguration)());
  };
  JQueryUI().AccordionIconConfiguration.get_Default =
  function()
  {
    return {header: "ui-icon-triangle-1-e",
            headerSelected: "ui-icon-triangle-1-s"};
  };
  Test().Main = function()
                {
                  return Test().Tests();
                };
  Test().Tests =
  function()
  {
    var _, __1, __4, __5, tab;
    __1 =
    OfArray()([["Accordion", Test().TestAccordian()],
               ["Autocomplete", Test().TestAutocomplete()],
               ["Button", Test().TestButton()],
               ["Datepicker", Test().TestDatepicker()]]);
    _ = function(arg00)
        {
          return Tabs().New2(arg00);
        };
    tab = _(__1);
    __5 = OfArray()([tab]);
    __4 = Html();
    return __4.Div(__5);
  };
  Test().TestAccordian =
  function()
  {
    var _, __1, __10, __12, __13, __15, __16, __17, __18, __19, __20, __21, __22,
        __23, __24, __26, __27, __4, __5, __6, __7, __8, __9, acc1, acc2, button,
        button_1, els1, els2;
    _ = Html();
    __4 = OfArray()([_.text("click")]);
    __1 = Html();
    __6 = OfArray()([__1.NewTag("button", __4)]);
    __5 = Html();
    __7 = Html();
    __9 = OfArray()([__7.text("Second content")]);
    __8 = Html();
    __10 = Html();
    __13 = OfArray()([__10.text("Third content")]);
    __12 = Html();
    els1 =
    OfArray()([["Foo", __5.Div(__6)], ["Bar", __8.Div(__9)],
               ["Baz", __12.Div(__13)]]);
    acc1 = New2()(els1);
    __15 =
    function(w)
    {
      return OnBeforeRender()(function()
                              {
                                var __14;
                                __14 = console;
                                return log().call(__14, "Acc1 - Before Render");
                              }, w);
    };
    __15(acc1);
    __16 =
    function(w)
    {
      return OnAfterRender()(function()
                             {
                               var __14;
                               __14 = console;
                               return log().call(__14, "Acc1 - After Render");
                             }, w);
    };
    __16(acc1);
    acc1.OnChange(function()
                  {
                    return function()
                           {
                             var __14;
                             __14 = console;
                             return log().call(__14, "Acc1 - Change");
                           };
                  });
    __18 = OfArray()([acc1]);
    __17 = Html();
    __19 = Html();
    __21 = OfArray()([__19.text("Second content")]);
    __20 = Html();
    __22 = Html();
    __24 = OfArray()([__22.text("Third content")]);
    __23 = Html();
    els2 =
    OfArray()([["Foo", __17.Div(__18)], ["Bar", __20.Div(__21)],
               ["Baz", __23.Div(__24)]]);
    acc2 = New2()(els2);
    acc2.OnChange(function()
                  {
                    return function()
                           {
                             var __14;
                             __14 = console;
                             return log().call(__14, "Acc2 - Change");
                           };
                  });
    button = New3()("Click");
    button.OnClick(function()
                   {
                     var __14, __25;
                     __14 = jQuery(acc2.element.Body);
                     __14.accordion("activate", 2);
                     __25 = jQuery(acc1.element.Body);
                     return __25.accordion("disable");
                   });
    button_1 = New3()("Click");
    button_1.OnClick(function()
                     {
                       var __14;
                       __14 = jQuery(acc2.element.Body);
                       return __14.accordion("activate", 1);
                     });
    __27 = OfArray()([acc2]);
    __26 = Html();
    return op_MinusLess()(__26.Div(__27), OfArray()([button_1]));
  };
  Test().TestAutocomplete =
  function()
  {
    var _, __1, __10, __12, __13, __14, __15, __6, __7, __8, __9, a, bClose,
        bDestroy, conf;
    conf = new (AutocompleteConfiguration())();
    conf.source = ["Apa", "Beta", "Zeta", "Zebra"];
    __1 = NewUnion()(FSharpList_1(), 0);
    _ = Html();
    a = New1_2()(_.NewTag("input", __1), conf);
    __28(a);
    __6 = function(w)
          {
            return OnAfterRender()(function()
                                   {
                                     var __4, __5;
                                     __4 = console;
                                     log().call(__4, "After Render");
                                     __5 = jQuery(a.element.Body);
                                     return __5.autocomplete("search", "Z");
                                   }, w);
          };
    __6(a);
    a.OnChange(function()
               {
                 return function()
                        {
                          var __4;
                          __4 = console;
                          return log().call(__4, "Change");
                        };
               });
    __7 = function(arg00)
          {
            return a.OnClose(arg00);
          };
    __8 = function()
          {
            return function()
                   {
                     var __4;
                     __4 = console;
                     return log().call(__4, "Close");
                   };
          };
    __7(__8);
    __9 = function(arg00)
          {
            return a.OnSearch(arg00);
          };
    __10 = function()
           {
             return function()
                    {
                      var __4;
                      __4 = console;
                      return log().call(__4, "Search");
                    };
           };
    __9(__10);
    __12 = function(arg00)
           {
             return a.OnFocus(arg00);
           };
    __13 = function()
           {
             return function()
                    {
                      var __4;
                      __4 = console;
                      return log().call(__4, "Focus");
                    };
           };
    __12(__13);
    bClose = New3()("Close");
    bClose.OnClick(function()
                   {
                     var __4;
                     __4 = jQuery(a.element.Body);
                     return __4.autocomplete("close");
                   });
    bDestroy = New3()("Destroy");
    bClose.OnClick(function()
                   {
                     var __4;
                     __4 = jQuery(a.element.Body);
                     return __4.autocomplete("destroy");
                   });
    __15 = OfArray()([a]);
    __14 = Html();
    return op_MinusLess()(__14.Div(__15), OfArray()([bClose, bDestroy]));
  };
  Test().TestButton =
  function()
  {
    var __1, __5, __6, b1, b2;
    b1 = New3()("Click");
    __1 = function(w)
          {
            return OnAfterRender()(function()
                                   {
                                     var _;
                                     _ = console;
                                     return log().call(_, "After Render");
                                   }, w);
          };
    __1(b1);
    __28(b1);
    b1.OnClick(function()
               {
                 var _;
                 _ = console;
                 return log().call(_, "Click");
               });
    b2 = New3()("Click 2");
    b2.OnClick(function()
               {
                 var __4;
                 b1.OnClick(function()
                            {
                              var _;
                              _ = console;
                              return log().call(_, "New CB");
                            });
                 if (b1.get_IsEnabled())
                 __4 = b1.Disable();
                 else
                 __4 = b1.Enable();
                 return __4;
               });
    __6 = OfArray()([b1, b2]);
    __5 = Html();
    return __5.Div(__6);
  };
  Test().TestDatepicker =
  function()
  {
    var _, __1, __5, __6, __7, __8, conf, dp;
    conf = new (DatepickerConfiguration())();
    __1 = NewUnion()(FSharpList_1(), 0);
    _ = Html();
    dp = New1_1()(_.NewTag("input", __1), conf);
    __5 = function(w)
          {
            return OnAfterRender()(function()
                                   {
                                     var __4;
                                     __4 = console;
                                     return log().call(__4, "Dp After Render");
                                   }, w);
          };
    __5(dp);
    __6 =
    function(w)
    {
      return OnBeforeRender()(function()
                              {
                                var __4;
                                __4 = console;
                                return log().call(__4, "Dp Before Render");
                              }, w);
    };
    __6(dp);
    __8 = OfArray()([dp]);
    __7 = Html();
    return __7.Div(__8);
  };
}())
