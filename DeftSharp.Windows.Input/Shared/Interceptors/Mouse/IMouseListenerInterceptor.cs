﻿using System;
using System.Collections.Generic;
using DeftSharp.Windows.Input.Mouse;
using DeftSharp.Windows.Input.Shared.Subscriptions;

namespace DeftSharp.Windows.Input.Shared.Interceptors.Mouse;

internal interface IMouseListenerInterceptor : IRequestedInterceptor
{
    IEnumerable<MouseSubscription> Subscriptions { get; }
    
    Coordinates GetPosition();

    void Subscribe(MouseEvent mouseEvent, Action onAction, TimeSpan intervalOfClick);
    void SubscribeOnce(MouseEvent mouseEvent, Action onAction);

    void Unsubscribe(MouseEvent mouseEvent);
    void Unsubscribe(Guid id);
    void UnsubscribeAll();
}